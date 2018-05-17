//
// This is designed to help the Purchase scripts activate the button that will allow players to select a skin or level pack.
//
// @Place this on the scene manager anywhere players can make a purchase
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    #region singleton
    public static ShopManager instance { set; get; }

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Button[] skinButtons;
    public Button[] levelButtons;

    void Start()
    {
        WhatDoIOwn();
    }

    public void ManageShopSkins(int input)
    {
        if (!skinButtons[input].interactable)
        {
            skinButtons[input].interactable = true;
        }
    }

    public void ManageShopLevels(int input)
    {
        if (!levelButtons[input].interactable)
        {
            levelButtons[input].interactable = true;
        }
    }

    void WhatDoIOwn()
    {
        for(int i = 0; i < skinButtons.Length; i++)
        {
            if (SaveManager.instance.IsSkinOwned(i))
            {
                skinButtons[i].interactable = true;
            }
            else
            {
                skinButtons[i].interactable = false;
            }
        }
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (SaveManager.instance.IsLevelPackOwned(i))
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
