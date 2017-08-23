// 
//  GreeAdsReward.cs
//  
// 
//  Copyright 2013 GREE, inc. All rights reserved.

using UnityEngine;

#if UNITY_IPHONE
using System;
using System.Runtime.InteropServices;
#endif

public class GreeAdsReward {
	private static GreeAdsRewardSDK sdk;
	
	public static void init() {
		if( sdk == null ) {
			sdk = getSDK();
		}
	}
	
	public static void setAppInfo(string pSiteID, string pSiteKey, bool pUseSandbox ) {
		GreeAdsReward.init ();
		sdk.setAppInfo( pSiteID, pSiteKey, pUseSandbox);
	}
	
	public static void setDevMode(bool devMode)
	{
		sdk.setDevMode( devMode );
	}
	
	public static void showOfferwall(int pMediaID, string pIdentifier)
	{
		sdk.showOfferwall( pMediaID, pIdentifier );
	}
	
	public static void showOfferwallByGreeLayout(int pMediaID, string pIdentifier)
	{
		sdk.showOfferwallByGreeLayout( pMediaID, pIdentifier );
	}
	
	public static void showCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		sdk.showCampaign( pMediaID, pIdentifier, pCampaignID );
	}
	
	public static void clickCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
		sdk.clickCampaign( pMediaID, pIdentifier, pCampaignID );
	}
	
	public static void showInterstitial( int pMediaID, string pIdentifier, CampaignType pCampaignType, string listnerName )
	{
		showInterstitial( pMediaID, pIdentifier, 0, pCampaignType, listnerName );
	}
	
	public static void showInterstitial( int pMediaID, string pIdentifier, int pCampaignID, CampaignType pCampaignType, string listnerName )
	{
		sdk.showInterstitial( pMediaID, pIdentifier, pCampaignID, pCampaignType, listnerName );
	}
//#if UNITY_IPHONE
	public static void sendAction( string pCampaignID, string pAdvertisement )
	{
		sendAction( pCampaignID, pAdvertisement,null );
	}
//#endif
	public static void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl )
	{
		init ();
		
		sdk.sendAction( pCampaignID, pAdvertisement, pCallbackUrl );
	}

	public static void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl, string pIdentifier )
	{
		init ();

		sdk.sendAction( pCampaignID, pAdvertisement, pCallbackUrl, pIdentifier );
	}

	private static GreeAdsRewardSDK getSDK() {
		if ( Application.platform == RuntimePlatform.Android )
		{
			return new GreeAdsRewardSDKAndroid();
		}
		else
		{
			return new GreeAdsRewardSDK();
		}
	}
}
