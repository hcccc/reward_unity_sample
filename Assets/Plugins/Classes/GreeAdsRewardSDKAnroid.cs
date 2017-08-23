// 
//  GreeAdsRewardSDKAnroid.cs
//  
// 
//  Copyright 2013 GREE, inc. All rights reserved.
// 

using UnityEngine;

public class GreeAdsRewardSDKAndroid : GreeAdsRewardSDK
{
#if UNITY_ANDROID
	private AndroidJavaClass gar;
	
	public GreeAdsRewardSDKAndroid() {
		this.gar = new AndroidJavaClass("net.gree.reward.sdk.unity.GreeAdsRewardBridge");
	}
	
	public override void setAppInfo ( string pSiteID, string pSiteKey, bool pUseSandbox )
	{
		gar.CallStatic("setAppInfo", pSiteID, pSiteKey, pUseSandbox);
	}
	
	public override void setDevMode(bool devMode)
	{
		gar.CallStatic("setDevMode", devMode);
	}
	
	public override void showOfferwall(int pMediaID, string pIdentifier)
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		gar.CallStatic("showOfferwall", unityActivity, pMediaID, pIdentifier);
	}
	
	public override void showOfferwallByGreeLayout(int pMediaID, string pIdentifier)
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		gar.CallStatic("showOfferwallByGreeLayout", unityActivity, pMediaID, pIdentifier);
	}
	
	public override void showCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		gar.CallStatic("showCampaign", unityActivity, pMediaID, pIdentifier, pCampaignID);
	}
	
	public override void clickCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		gar.CallStatic("clickCampaign", unityActivity, pMediaID, pIdentifier, pCampaignID);
	}
	
	public override void showInterstitial( int pMediaID, string pIdentifier, CampaignType pCampaignType, string listnerName )
	{
		showInterstitial( pMediaID, pIdentifier, 0, pCampaignType, listnerName );
	}
	
	public override void showInterstitial( int pMediaID, string pIdentifier, int pCampaignID, CampaignType pCampaignType, string listnerName )
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                gar.CallStatic("showInterstitialForUnity", unityActivity, pMediaID, pIdentifier, pCampaignID, (int)pCampaignType, listnerName);
        }));
	}
	
	public override void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl )
	{
		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();
		
		gar.CallStatic<bool>("sendAction", unityActivity, pCampaignID, pAdvertisement, pCallbackUrl);
	}

	public override void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl, string pIdentifier )
	{
		Debug.Log ("Trigger android sendaction");

		AndroidJavaObject unityActivity = GreeAdsRewardUtil.getCurrentActivity();

		gar.CallStatic<bool>("sendAction", unityActivity, pCampaignID, pAdvertisement, pCallbackUrl, pIdentifier);
	}
#endif
}