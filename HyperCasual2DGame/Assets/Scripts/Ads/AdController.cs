using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string store_id = "3289656";

    private string video_ad = "video";
  //  private string rewareded_video_ad = "rewardedVideo";
   // private string banner_ad = "GameBanner";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("AdFree"))
        {
            return;
        }
        else
        {
            Advertisement.Initialize(store_id, true);
        }
    }

    public void showVideoAD()
    {
        if (PlayerPrefs.HasKey("AdFree"))
        {
            return;
        }
        else
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");

            }
        }
    }

    public void showBannerAD()
    {
      /*  if (Advertisement.IsReady("GameBanner"))
        {
                Advertisement.Show("GameBanner");
            
        }*/
    }


}
