using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class adManager : MonoBehaviour
{
    public static adManager instance;
    private string appID = "ca-app-pub-9842952727279710~9051686916";
    private RewardBasedVideoAd rewarded;
    private string rewardedID = "ca-app-pub-9842952727279710/4105825457";
    [SerializeField]
    private Button rewardButton;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        MobileAds.Initialize(appID);
        rewarded = RewardBasedVideoAd.Instance;
    }

    public void RequestReward()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rewarded.LoadAd(request, rewardedID);
    }

    public void ShowRewarded()
    {
        if (rewarded.IsLoaded())
        {
            rewarded.Show();
        }
        else
        {
            print("anuncio sin cargar");
        }
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        Debug.Log(args.Amount);
        rewardButton.interactable = false;
        int puntos = PlayerPrefs.GetInt("losePoints");
        PlayerPrefs.SetInt("losePoints", puntos / 2);
    }
}
