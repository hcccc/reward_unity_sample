// 
//  GreeAdsRewardSDK.cs
//  
// 
//  Copyright 2013 GREE, inc. All rights reserved.
// 

public enum CampaignType
{
	NONE		= 0,
	NORMAL		= 1,
	XPROMOTION	= 2,
	ALL			= 3
}

public class GreeAdsRewardSDK
{
	public virtual void setAppInfo ( string pSiteID, string pSiteKey, bool pUseSandbox )
	{	
	}
	
	public virtual void setDevMode(bool devMode)
	{	
	}
	
	public virtual void showOfferwall(int pMediaID, string pIdentifier)
	{	
	}
	
	public virtual void showOfferwallByGreeLayout(int pMediaID, string pIdentifier)
	{
	}
	
	public virtual void showCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
	}
	
	public virtual void clickCampaign( int pMediaID, string pIdentifier, int pCampaignID )
	{
	}
	
	public virtual void showInterstitial( int pMediaID, string pIdentifier, CampaignType pCampaignType, string listnerName )
	{
	}
	
	public virtual void showInterstitial( int pMediaID, string pIdentifier, int pCampaignID, CampaignType pCampaignType, string listnerName )
	{
	}
	
	public virtual void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl )
	{
	}

	public virtual void sendAction( string pCampaignID, string pAdvertisement, string pCallbackUrl, string pIdentifier )
	{
	}
}