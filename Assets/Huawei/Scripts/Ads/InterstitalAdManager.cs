﻿using HuaweiMobileServices.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InterstitalAdManager : MonoBehaviour
{
    private class InterstitialAdListener : IAdListener
    {
        private readonly InterstitalAdManager mAdsManager;

        public InterstitialAdListener(InterstitalAdManager adsManager)
        {
            mAdsManager = adsManager;
        }

        public void OnAdClicked()
        {
            Debug.Log("[HMS] AdsManager OnAdClicked");
            mAdsManager.OnAdClicked?.Invoke();
        }

        public void OnAdClosed()
        {
            Debug.Log("[HMS] AdsManager OnAdClosed");
            mAdsManager.OnAdClicked?.Invoke();
            mAdsManager.LoadNextInterstitialAd();
        }

        public void OnAdFailed(int reason)
        {
            Debug.Log("[HMS] AdsManager OnAdFailed");
            mAdsManager.OnAdFailed?.Invoke(reason);
        }

        public void OnAdImpression()
        {
            Debug.Log("[HMS] AdsManager OnAdImpression");
            mAdsManager.OnAdImpression?.Invoke();
        }

        public void OnAdLeave()
        {
            Debug.Log("[HMS] AdsManager OnAdLeave");
            mAdsManager.OnAdLeave?.Invoke();
        }

        public void OnAdLoaded()
        {
            Debug.Log("[HMS] AdsManager OnAdLoaded");
            mAdsManager.OnAdLoaded?.Invoke();
        }

        public void OnAdOpened()
        {
            Debug.Log("[HMS] AdsManager OnAdOpened");
            mAdsManager.OnAdOpened?.Invoke();
        }
    }

    private const string NAME = "InterstitalAdManager";

    public static InterstitalAdManager Instance => GameObject.Find(NAME).GetComponent<InterstitalAdManager>();

    private InterstitialAd interstitialAd = null;

    public string AdId { get; set; }
    public Action OnAdClicked { get; set; }
    public Action OnAdClosed { get; set; }
    public Action<int> OnAdFailed { get; set; }
    public Action OnAdImpression { get; set; }
    public Action OnAdLeave { get; set; }
    public Action OnAdLoaded { get; set; }
    public Action OnAdOpened { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[HMS] AdsManager Start");
        LoadNextInterstitialAd();
    }

    private void LoadNextInterstitialAd()
    {
        Debug.Log("[HMS] AdsManager LoadNextInterstitialAd");
        interstitialAd = new InterstitialAd
        {
            AdId = "testb4znbuh3n2",
            AdListener = new InterstitialAdListener(this)
        };
        interstitialAd.LoadAd(new AdParam.Builder().Build());
    }

    public void ShowInterstitialAd()
    {
        Debug.Log("[HMS] AdsManager ShowInterstitialAd");
        if (interstitialAd?.Loaded == true)
        {
            Debug.Log("[HMS] AdsManager interstitialAd.Show");
            interstitialAd.Show();
        }
        else
        {
            Debug.Log("[HMS] Interstitial ad clicked but still not loaded");
        }
    }
}
