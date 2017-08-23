//
//  GreeAdsRewardSample.cs
//
//
//  Copyright 2013 GREE, inc. All rights reserved.


/********************************************************************************
  *
  *  In order to show the buttons on screen,
  *
  *  please add this script to the scene's "TopMenu"
  *
  *******************************************************************************/

using UnityEngine;
using System.Collections;

public class GreeAdsRewardSample : MonoBehaviour {
  [System.Serializable]
  public class AccountInfo{
    //set account info to yours
    public string siteId;
    public string siteKey;
    public bool useSandbox;

    //setting for publisher
    public int mediaID;

    //setting for advertisment
    public string campaignID;
    public string advertisement;
    public string url_scheme;


   }

  [SerializeField]
  private AccountInfo accountInfoAndroid;
  [SerializeField]
  private AccountInfo accounInfoIOS;

  AccountInfo info()
  {
#if UNITY_IPHONE
    return accounInfoIOS;
#else
    return accountInfoAndroid;
#endif
  }

  void Start(){
    print("[mytest] set app info");
    // Set GreeAdsReward account info.
    // グリーリワードのアカウントを設定する
    GreeAdsReward.setAppInfo(this.info().siteId.Trim(), this.info().siteKey.Trim(), this.info().useSandbox);
	GreeAdsReward.setDevMode (true);
  }

    void OnGUI () {

        // Make a background box
        GUI.Box(new Rect(10, 10, Screen.width-20, Screen.height-20), "Gree Ads Reward Sample");

        if(GUI.Button(new Rect(35,100,Screen.width - 70,  100), "OfferWall")) {
            // Show Offerwall
            // オファーウォールを表示する
            GreeAdsReward.showOfferwall(this.info().mediaID, "identifier");
        }

        if(GUI.Button(new Rect(35,250,Screen.width - 70, 100), "Interstitial")) {
            //  shwo interstitial ads.
            // インタースティシャル広告を表示する
            GreeAdsReward.showInterstitial(this.info().mediaID, "identifier", CampaignType.XPROMOTION, "Main Camera");
        }

#if UNITY_ANDROID
        if(GUI.Button(new Rect(35,400,Screen.width - 70, 100), "send Action")) {
            // send achieve(conversion) info
            // 成果通信
			string campaignId = this.info().campaignID.Trim();
			string advertisement = this.info().advertisement.Trim();
			string urlScheme = this.info().url_scheme.Trim();
			Debug.Log("campaignId: " + campaignId);
			Debug.Log("advertisement: " + advertisement);
			Debug.Log("urlScheme: " + urlScheme);

			Debug.Log("Call Android function");
			using (AndroidJavaClass javaCalss = new AndroidJavaClass ("com.kddi.alml.AlmlLicensePlugin")) {
				bool loginResult = javaCalss.CallStatic<bool> ("showLoginResult");
				Debug.Log("Login Result: " + loginResult);

				if (!loginResult) {
					// Close the application if login has failed.
					Application.Quit();
				}

			}
			int randomId = Random.Range(0, 100);
			GreeAdsReward.sendAction(this.info().campaignID.Trim(), this.info().advertisement.Trim(), this.info().url_scheme.Trim(), "sample_identifier_"+randomId.ToString());
        }
#endif

#if UNITY_IPHONE
        if(GUI.Button(new Rect(35,400,Screen.width - 70, 100), "send Action for iOS")) {
            // send achieve(conversion) info
            // 成果通信
            GreeAdsReward.sendAction(this.info().campaignID.Trim(), this.info().advertisement.Trim());
        }
#endif

    }


   //delegate method for interstitial ad
  public void onGreeAdsRewardInterstitialStartLoading(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialStartLoading");
  }

  public void onGreeAdsRewardInterstitialLoadFailed(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialLoadFailed");
  }

  public void onGreeAdsRewardInterstitialViewWillAppear(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialViewWillAppear");
  }

  public void onGreeAdsRewardInterstitialViewDidAppear(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialViewDidAppear");
  }

  public void onGreeAdsRewardInterstitialViewWillClose(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialViewWillClose");
  }

  public void onGreeAdsRewardInterstitialViewDidClose(string msg)
  {
    Debug.Log("[unity]onGreeAdsRewardInterstitialViewDidClose");
  }

}
