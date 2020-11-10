using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class adManager : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3896163";
    string myPlacementId = "restorePoints";
    bool testMode = true;
    //public static adManager instance;
    //private string appID = "ca-app-pub-9842952727279710~9051686916";
    //private RewardBasedVideoAd rewarded;
    //private string rewardedID = "ca-app-pub-9842952727279710/4105825457";
    [SerializeField]
    private Button rewardButton;
    //void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this);
    //    }
    //}
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        
        //MobileAds.Initialize(appID);
        //rewarded = RewardBasedVideoAd.Instance;
    }

    public void RequestReward()
    {
        //AdRequest request = new AdRequest.Builder().Build();
        //rewarded.LoadAd(request, rewardedID);
    }

    public void ShowRewarded()
    {
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
        //if (rewarded.IsLoaded())
        //{
        //    rewarded.Show();
        //}
        //else
        //{
        //    print("anuncio sin cargar");
        //}
    }

    //public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    //{
    //    Debug.Log(args.Amount);
    //    rewardButton.interactable = false;
    //    int puntos = PlayerPrefs.GetInt("losePoints");
    //    PlayerPrefs.SetInt("losePoints", puntos / 2);
    //}

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            rewardButton.interactable = true;
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            rewardButton.interactable = false;
            int puntos = PlayerPrefs.GetInt("losePoints");
            PlayerPrefs.SetInt("losePoints", puntos / 2);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
