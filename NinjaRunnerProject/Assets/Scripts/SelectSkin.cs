//
// This is placed on the button that will allow players to select a skin they would like to use
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinPurchase))]
public class SelectSkin : MonoBehaviour
{
    private SkinPurchase newSkinPurchase;

    public Sprite skin;

    void Start()
    {
        newSkinPurchase = GetComponent<SkinPurchase>();
    }

    public void DetermineSkin()
    {
        SaveManager.instance.state.currentSkin = skin;
        print(SaveManager.instance.state.currentSkin.name);
    }
}
