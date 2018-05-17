//
// This script is used for any button that can lead to the purchase of a level pack for the player.
//
//This does not need to be placed onto an object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPackPurchase : MonoBehaviour
{
    public int currencyRequired;
    public int packPurchaseNumber;
    public Button purchaseButton;

    void Start()
    {
        WhatDoIOwn();
    }

    public void PurchaseLevelPack(int input)
    {
        if(SaveManager.instance.state.scrollOwned >= currencyRequired)
        {
            input = packPurchaseNumber;

            SaveManager.instance.UnlockLevelPack(input);
            SaveManager.instance.state.scrollOwned -= currencyRequired;
            ShopManager.instance.ManageShopLevels(input);
            purchaseButton.interactable = false;
            purchaseButton.GetComponentInChildren<Text>().text = "Purchased";
        }
        else
        {
            print("Not enough currency");
        }

        return;
    }

    void WhatDoIOwn()
    {
        if (SaveManager.instance.IsLevelPackOwned(packPurchaseNumber))
        {
            purchaseButton.interactable = false;
            purchaseButton.GetComponentInChildren<Text>().text = "Purchased";
        }
        else
        {
            purchaseButton.interactable = true;
        }
    }
}
