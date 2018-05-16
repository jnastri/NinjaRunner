using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour
{
    #region singleton
    public static AdManager instance { set; get; }

    void Awake()
    {
        instance = this;
    }
    #endregion

    [HideInInspector]
    public bool paidNoAds;
    [HideInInspector]
    public bool loadingLevel;
    [HideInInspector]
    public string loadLevelName;

    public void OnPlayButton()
    {
        if (!paidNoAds)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResults });
            }
        }
        else
        {
            SceneManager.LoadScene(loadLevelName);
            loadingLevel = false;
        }
    }

    public void ShowAdAfterLevel()
    {
        if (!paidNoAds)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResults });
            }
        }
        else
        {
            SceneManager.LoadScene(loadLevelName);
            loadingLevel = false;
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
                if (loadingLevel)
                {
                    SceneManager.LoadScene(loadLevelName);
                    loadingLevel = false;
                }
                Debug.Log("Get a Scroll");
                break;
            case ShowResult.Skipped:
                Debug.Log("Be sure to watch the ad all the way through to get a scroll for new in-game items");
                if (loadingLevel)
                {
                    SceneManager.LoadScene(loadLevelName);
                    loadingLevel = false;
                }
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad ?Internet?");
                loadingLevel = false;
                break;
            default:
                break;
        }
    }
}
