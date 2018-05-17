//
// This script is used for any button that can lead to the purchase of a skin for the character.
//
// You do not need to place this on an object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPurchase : MonoBehaviour
{
    public int currencyRequired;
    public int skinPurchaseNumber;
    public Button purchaseButton;

    void Start()
    {
        WhatDoIOwn();
    }

    public void PurchaseSkin(int input)
    {
        print(SaveManager.instance.state.scrollOwned);
        print(currencyRequired);
        if (SaveManager.instance.state.scrollOwned >= currencyRequired)
        {
            print(SaveManager.instance.state.scrollOwned);
            input = skinPurchaseNumber;

            SaveManager.instance.UnlockSkin(input);
            SaveManager.instance.state.scrollOwned -= currencyRequired;
            ShopManager.instance.ManageShopSkins(input);
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
        if (SaveManager.instance.IsSkinOwned(skinPurchaseNumber))
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
