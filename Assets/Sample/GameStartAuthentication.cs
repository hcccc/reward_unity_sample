using UnityEngine;
using System.Collections;

public class GameStartAuthentication : MonoBehaviour {

	[System.Serializable]
	public class AccountInfo {
		//set account info to yours
		public string siteId;
		public string siteKey;
		public bool useSandbox;

		//setting for advertisment
		public string campaignID;
		public string advertisement;
		public string url_scheme;
	}

	[SerializeField]
	private AccountInfo accountInfoAndroid;
	private AndroidJavaClass aumlPluginClass;
	private bool initialSetupDone = false;

	AccountInfo info() {
		#if UNITY_ANDROID
		return accountInfoAndroid;
		#endif
	}

	void Start() {
		#if UNITY_ANDROID
		if (!initialSetupDone) {
			Debug.Log("[START] Start the App");
			initialSetupDone = true;
			GreeAdsReward.setAppInfo(this.info().siteId.Trim(), this.info().siteKey.Trim(), this.info().useSandbox);
			GreeAdsReward.setDevMode(true);

			// Trigger sendAction() call with no identifier specified.
			GreeAdsReward.sendAction(this.info().campaignID.Trim(), this.info().advertisement.Trim(), this.info().url_scheme.Trim(), null);

			aumlPluginClass = new AndroidJavaClass ("com.kddi.alml.AlmlLicensePlugin");
			aumlPluginClass.CallStatic("showDialog", "auマーケットと通信中です");

			bool loginResult = aumlPluginClass.CallStatic<bool>("login");
			if (!loginResult) {
				aumlPluginClass.CallStatic("showErrorMsg");
				StartCoroutine(exitApp());
			} else {
				StartCoroutine(waitForLoginCallback());
			}
		}
		#endif
	}

	private void dismissAndroidNativeDialog() {
		aumlPluginClass.CallStatic ("dismissDialog");
	}

	private IEnumerator waitForLoginCallback() {
		bool loginResponse = aumlPluginClass.CallStatic<bool>("checkResponse");
		int timelimit = 10;

		for (int i = 0; i < timelimit; i++) {
			if (loginResponse) {
				break;
			}
			yield return new WaitForSecondsRealtime (1);
			loginResponse = aumlPluginClass.CallStatic<bool>("checkResponse");
		}
		bool loginResult = aumlPluginClass.CallStatic<bool>("checkLoginResult");
		if (!loginResult) {
			aumlPluginClass.CallStatic ("showErrorMsg");
			StartCoroutine (exitApp ());
		} else {
			// Login succesfully, dismiss dialogs
			Invoke("dismissAndroidNativeDialog", 2);
		}
	}

	private IEnumerator exitApp() {
		yield return new WaitForSecondsRealtime(3);
		Debug.Log ("Ready to close the app.");
		Application.Quit ();
	}

}
