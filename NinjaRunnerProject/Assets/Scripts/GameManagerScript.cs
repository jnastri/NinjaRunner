using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    #region singleton
    public static GameManagerScript instance { set; get; }
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    [HideInInspector]
    public int currentScrolls;
}
