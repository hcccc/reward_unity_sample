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
	private static bool initialSetupDone = false;
	private int dialogDismissTime = 4; //secs

	AccountInfo info() {
		#if UNITY_ANDROID
		return accountInfoAndroid;
		#endif
	}

	void Start() {
		#if UNITY_ANDROID
		if (!initialSetupDone) {
			initialSetupDone = true;
			aumlPluginClass = new AndroidJavaClass ("com.kddi.alml.AlmlLicensePlugin");
			bool bindResult = aumlPluginClass.CallStatic<bool>("verifyAuLogin");
			Debug.Log("Bind Result: " + bindResult);
			if (!bindResult) {
				Invoke ("triggerQuit", 3);
			}
		}
		#endif
	}

	void onLoginSuccess(string msg) {
		Debug.Log ("[UnitySendMessage] Login Success: " + msg);
		performSupershipSDKAction ();
	}

	void onLoginFailure(string msg) {
		Debug.Log ("[UnitySendMessage] Login Failure: " + msg);
		Invoke ("triggerQuit", 3);
	}

	private void performSupershipSDKAction() {
		GreeAdsReward.setAppInfo(this.info().siteId.Trim(), this.info().siteKey.Trim(), this.info().useSandbox);
		GreeAdsReward.setDevMode(true);

		// Trigger sendAction() call with deviceUniqueIdentifier.
		// string uniqueId = SystemInfo.deviceUniqueIdentifier;
		int randomId = Random.Range(1, 999999);
		GreeAdsReward.sendAction(this.info().campaignID.Trim(), this.info().advertisement.Trim(), this.info().url_scheme.Trim(), "identifier" + randomId);
	}


	private void triggerQuit() {
		Application.Quit ();
	}
}
