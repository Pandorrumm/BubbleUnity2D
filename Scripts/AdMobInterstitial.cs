using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class AdMobInterstitial : MonoBehaviour
{
    public string AppID;
    public string InterstitialAdUnitID;
    private InterstitialAd interstitialAd;
    

    void Start()
    {
        MobileAds.Initialize(AppID);
        interstitialAd = new InterstitialAd(InterstitialAdUnitID);
        interstitialAd.LoadAd(new AdRequest.Builder().Build());
        interstitialAd.OnAdClosed += HandlerOnClosed;
    }

    public void HandlerOnClosed(object sendler, EventArgs args)
    {       
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowAds()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {           
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
