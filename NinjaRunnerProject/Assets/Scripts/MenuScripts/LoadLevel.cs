using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    [SerializeField]
    private bool willHaveAd;

    public void EnterLevel()
    {
        if (willHaveAd)
        {
            AdManager.instance.loadingLevel = true;
            AdManager.instance.loadLevelName = levelName;
            AdManager.instance.ShowAdAfterLevel();
        }
    }
}
