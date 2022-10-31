using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AdsInitializer : MonoBehaviour, IUnityAdsListener
{
    public static AdsInitializer instance;
    [SerializeField] string _androidGameId;
    public int AdsTimesPerGame;
    public float Reward;

    public int TimesUntilAd = 3;
    public int CurrentAd;

    public Button AdsButton;
    void Awake()
    {
        CurrentAd = PlayerPrefs.GetInt("AdCount");
        instance = this;
        Advertisement.Initialize(_androidGameId);
        Advertisement.AddListener(this);

    }
    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded Ad is not Ready");
        }
    }
    


    public void PlayNormalAd()
    {
        if(PlayerPrefs.GetInt("AdCount") <= 0)
        {
            if (Advertisement.IsReady("Interstitial_Android"))
            {
                Advertisement.Show("Interstitial_Android");
                PlayerPrefs.SetInt("AdCount", TimesUntilAd);
            }
            else
            {
                Debug.Log("Rewarded Ad is not Ready");
            }
        }

        else if(PlayerPrefs.GetInt("AdCount") >= 1)
        {
            CurrentAd = PlayerPrefs.GetInt("AdCount");
            CurrentAd--;
            PlayerPrefs.SetInt("AdCount", CurrentAd);
            UI_Manager.instance.ResetLevel();
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == "Rewarded_Android")
        {
            AdsTimesPerGame--;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            UI_Manager.instance.AdRestart(Reward);
            Debug.Log("Player Rewarded");
        }
        if (placementId == "Interstitial_Android")
        {
            UI_Manager.instance.ResetLevel();
            Debug.Log("Ad Finished");
        }
    }
    private void Update()
    {
        if (Advertisement.IsReady("Rewarded_Android") && AdsTimesPerGame >= 1)
        {
            AdsButton.interactable = true;
        }
        else
        {
            AdsButton.interactable = false;
        }
    }
}