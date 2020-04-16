using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

    private void Start()
    {
        string appId = "ca-app-pub-3940256099942544~3347511713";

        MobileAds.Initialize(appId);

        RequestInterstitial();
        RequestBanner();
        RequestRewardBasedVideo();
    }


    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        AdSize adSize = new AdSize(250, 100);
        bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

      interstitial = new InterstitialAd(adUnitId);
        interstitial.OnAdClosed += AdsClose;

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    private void RequestRewardBasedVideo()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";

        AdRequest request = new AdRequest.Builder().Build();
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdClosed += RewardAdsClose;
        rewardBasedVideo.LoadAd(request, adUnitId);
    }

    private void AdsClose(object obj, EventArgs args)
    {
        RequestInterstitial();
    }

    private void RewardAdsClose(object obj, EventArgs args)
    {
        RequestRewardBasedVideo();
    }

    public void OnShowAds()
    {
        if (interstitial.IsLoaded())
            interstitial.Show();

    }

    public void OnShowRewardAds()
    {
        if (rewardBasedVideo.IsLoaded())
            rewardBasedVideo.Show();
    }

}
