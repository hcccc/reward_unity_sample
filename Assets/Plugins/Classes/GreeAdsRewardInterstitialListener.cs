// 
//  GreeAdsRewardInterstitialListener.cs
// 
//  Copyright 2013 GREE, inc. All rights reserved.
//
//	Usage:
//		Please attach this script to your 'Main Camera' object.
//		And do your customized operation here.
//
// 

using UnityEngine;

public class GreeAdsRewardInterstitialListener : MonoBehaviour
{
	/*
	 * 
	 * Called when it starts to fetch interstitial ads from Reward Server.
	 * 
	 */
	public void onGreeAdsRewardInterstitialStartLoading(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialStartLoadingUnity");
	}
	
	/*
	 * 
	 * Called when interstitial ads is successfully fetched from server,
	 * and the GreeAdsRewardInterstitial activity is about to take over
	 * the control.
	 * 
	 */
	public void onGreeAdsRewardInterstitialViewWillAppear(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialViewWillAppearUnity");
	}
	
	/*
	 *  DO NOT TRUST THIS METHOD.
	 * 
	 *  When this mechod gets called, the UnityPlayer Activity is not
	 *  in control, this message WILL BE DELAYED until UnityPlayer
	 *  get the control back.
	 * 
	 *  Why UnityPlayer is not in control?
	 *  Because the activity showed to user is GreeAdsRewardInterstitial.
	 *  And this listener is attached to a Unity Object.
	 * 
	 */
	public void onGreeAdsRewardInterstitialViewDidAppear(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialViewDidAppearUnity");
	}
	
	/*
	 *  DO NOT TRUST THIS METHOD.
	 * 
	 *  When this mechod gets called, the UnityPlayer Activity is not
	 *  in control, this message WILL BE DELAYED until UnityPlayer
	 *  get the control back.
	 * 
	 *  Why UnityPlayer is not in control?
	 *  For the same reason you read above.
	 * 
	 */
	public void onGreeAdsRewardInterstitialViewWillClose(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialViewWillCloseUnity");
	}
	
	/*
	 * 
	 * Called when interstitial ads is dismissed.
	 * 
	 */
	public void onGreeAdsRewardInterstitialViewDidClose(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialViewDidCloseUnity");
	}
	
	/*
	 * 
	 * Called when there is something wrong with the loading process.
	 * Sometimes a network timeout, or a network failure, etc.
	 * 
	 */
	public void onGreeAdsRewardInterstitialLoadFailed(string msg)
	{
		Debug.Log("onGreeAdsRewardInterstitialLoadFailedUnity");
	}
	
}