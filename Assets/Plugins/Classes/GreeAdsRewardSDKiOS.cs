// 
//  GreeAdsRewardSDKiOS.cs
//  
// 
//  Copyright 2013 GREE, inc. All rights reserved.
// 

using UnityEngine;
using System.Runtime.InteropServices;

public class GreeAdsRewardSDKiOS : GreeAdsRewardSDK
{
#if UNITY_IPHONE
    [DllImport("__Internal")] private static extern void _setAppInfo (string siteID, string siteKey, bool useSandBox);
	[DllImport("__Internal")] private static extern void _setDevMode (bool devMode);
	[DllImport("__Internal")] private static extern void _showOfferWall(string mediaID, string identifier);
	[DllImport("__Internal")] private static extern void _showCampaign(string mediaID, string identifier, string campaignID);
	[DllImport("__Internal")] private static extern void _clickCampaign(string mediaID, string identifier, string campaignID);
	[DllImport("__Internal")] private static extern void _sendActionWithCampaignID(string campaignID, string advertisement, string callBackURL);
	[DllImport("__Internal")] private static extern void _showInterstitial(string mediaID, string identifier, int campaignType, string campaignID, string listenerName);
	
	public GreeAdsRewardSDKiOS() {
		
	}
	
	public override void setAppInfo ( string pSiteID, string pSiteKey, bool pUseSandbox )
	{
		_setAppInfo (pSiteID, pSiteKey, pUseSandbox);
	}
	
	public override void setDevMode(bool devMode)
	{
		_setDevMode(devMode);
	}
	
	public override void showOfferwall(int pMediaID, string pIdentifier)
	{
		_showOfferWall(pMediaID.ToString(), pIdentifier);
	}

	public override void showCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		_showCampaign(pMediaID.ToString(), pIdentifier, pCampaignID.ToString());
	}
	
	public override void clickCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		_clickCampaign(pMediaID.ToString(), pIdentifier, pCampaignID.ToString());
	}
	
	public override void showInterstitial( int pMediaID, string pIdentifier, CampaignType pCampaignType, string listnerName )
	{
		showInterstitial(pMediaID, pIdentifier, 0, pCampaignType, listnerName);
	}
	
	public override void showInterstitial( int pMediaID, string pIdentifier, int pCampaignID, CampaignType pCampaignType, string listnerName )
	{
		_showInterstitial(pMediaID.ToString(), pIdentifier, (int)pCampaignType, pCampaignID.ToString(), listnerName);
	}
	
	public override void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl )
	{
		_sendActionWithCampaignID(pCampaignID.ToString(), pAdvertisement, pCallbackUrl);
	}

	public override void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl, string pIdentifier )
	{
		_sendActionWithCampaignID(pCampaignID.ToString(), pAdvertisement, pCallbackUrl);
	}
#endif
}