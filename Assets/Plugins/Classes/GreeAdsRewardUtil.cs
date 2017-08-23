// 
//  GreeAdsRewardUtil.cs
//  
// 
//  Copyright 2013 GREE, inc. All rights reserved.
// 

using UnityEngine;

public class GreeAdsRewardUtil
{
#if UNITY_ANDROID
	public static AndroidJavaObject getCurrentActivity() {
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		
		return unityActivity;
	}
#endif
}