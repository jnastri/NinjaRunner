using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public void ShowAdAfterLevel()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResults });
        }
    }

    public void ShowAdOnClick()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResults });
        }
    }

    void HandleAdResults(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Get a Scroll");
                break;
            case ShowResult.Skipped:
                Debug.Log("Be sure to watch the ad all the way through to get a scroll for new in-game items");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad ?Internet?");
                break;
            default:
                break;
        }
    }
}
