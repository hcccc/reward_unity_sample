//
//  GreeAdsRewardUnityPlugin.h
//  GreeAdsRewardUnityPlugin
//  VERSION: 1.1.0
//
//  Copyright 2013 GREE, inc. All rights reserved.
//
//

#import <Foundation/Foundation.h>
#import "GreeAdsReward.h"
#import "GreeAdsRewardInterstitialListener.h"

UIViewController *UnityGetGLViewController();

// convinient function
static NSString* CreateNSString(const char* string)
{
    if (string != NULL)
        return [NSString stringWithUTF8String:string];
    else
        return [NSString stringWithUTF8String:""];
}

extern "C" {
    
    void _setAppInfo(const char* siteIDPtr, const char* siteKeyPtr, BOOL useSandBox) {
        
        NSString *siteKey = CreateNSString(siteKeyPtr);
        NSString *siteID = CreateNSString(siteIDPtr);
        
        [GreeAdsReward setSiteID:siteID siteKey:siteKey useSandBox:useSandBox];
    }
    
    void _setDevMode(BOOL devMode) {
        [GreeAdsReward setDevMode:devMode];
    }
    
    void _showOfferWall(const char* mediaIDPtr, const char* identifierPtr, BOOL withAnimation) {
        NSString *mediaID = CreateNSString(mediaIDPtr);
        NSString *identifier = CreateNSString(identifierPtr);
        
        [GreeAdsReward showOfferWallWithMeidaID:mediaID identifier:identifier];
    }
    
    void _showCampaign(const char* mediaIDPtr, const char* identifierPtr, const char* campaignIDPtr, BOOL withAnimation) {
        NSString *mediaID = CreateNSString(mediaIDPtr);
        NSString *identifier = CreateNSString(identifierPtr);
        NSString *campaignID = CreateNSString(campaignIDPtr);
        
        [GreeAdsReward showOfferWallWithMeidaID:mediaID identifier:identifier campaignID:campaignID];
    }
    
    void _clickCampaign(const char* mediaIDPtr, const char* identifierPtr, const char* campaignIDPtr) {
        NSString *mediaID = CreateNSString(mediaIDPtr);
        NSString *identifier = CreateNSString(identifierPtr);
        NSString *campaignID = CreateNSString(campaignIDPtr);
        
        [GreeAdsReward clickCampaign:campaignID mediaID:mediaID identifier:identifier];
    }
    
    void _sendActionWithCampaignID(const char*campaignIDPtr, const char* advertisementPtr, const char*callBackURLPtr) {
        NSString *campaignID = CreateNSString(campaignIDPtr);
        NSString *advertisement = CreateNSString(advertisementPtr);

        if (callBackURLPtr == NULL) {
            [GreeAdsReward sendActionWithCampaignID:campaignID advertisement:advertisement];
        } else {
            NSString *callBackURL = CreateNSString(callBackURLPtr);
            [GreeAdsReward sendActionWithCampaignID:campaignID advertisement:advertisement callBackURL:callBackURL];
        }
    }
    
    void _showInterstitial(const char* mediaIDPtr, const char* identifierPtr, int cType, const char* campaignIDPtr, const char* listenerNamePtr) {
        NSString *mediaID = CreateNSString(mediaIDPtr);
        NSString *identifier = CreateNSString(identifierPtr);
        NSString *listenerName = CreateNSString(listenerNamePtr);
        
        GreeAdsRewardCampaignType campaignType = GreeAdsRewardCampaignTypeNone;
        
        switch (cType) {
            case 1:
                campaignType = GreeAdsRewardCampaignTypeNormal;
                break;
            case 2:
                campaignType = GreeAdsRewardCampaignTypeXpromotion;
                break;
            case 3:
                campaignType = GreeAdsRewardCampaignTypeAll;
                break;
            default:
                campaignType = GreeAdsRewardCampaignTypeNone;
                break;
        }
        
        GreeAdsRewardInterstitialListener *listener = [[GreeAdsRewardInterstitialListener alloc] initWithName:listenerName];
        
        if (campaignIDPtr == NULL) {
            [GreeAdsReward showInterstitial:mediaID identifier:identifier campaignType:campaignType delegate:listener];
        } else {
            NSString *campaignID = CreateNSString(campaignIDPtr);
            [GreeAdsReward showInterstitial:mediaID identifier:identifier campaignType:campaignType campaignID:campaignID delegate:listener];
        }
    }
}
