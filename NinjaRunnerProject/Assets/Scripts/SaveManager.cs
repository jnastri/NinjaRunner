//
// This script is used to actively used stored data in the SaveState script.
// This script should be called when you would like to unlock a skin after the player purchase it from the shop or is rewarded for a type of feat.
//
//This belongs on the game manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        Load();
    }

    //Save the whole state of this saveState script to the player pref.
    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    //Load the previous saved state from the player prefs.
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();

        }
    }

    //Check if the skin is owned
    public bool IsSkinOwned(int index)
    {
        //Check if the bit is set, if so the skin is owned
        return(state.skinOwned & (1 << index)) != 0;
    }

    //Check if the level pack is owned
    public bool IsLevelPackOwned(int index)
    {
        //Check if the bit is set, if so the skin is owned
        return (state.skinOwned & (1 << index)) != 0;
    }

    //Unlock a skin in the "skinOwned" int
    public void UnlockSkin(int index)
    {
        // Toggle on the bit at index
        // To toggle on use |=
        // To toggle off a bit use alt+94 then = (Example: ^= )
        state.skinOwned |= 1 << index;
    }

    //Unlock a level in the "levelPackOwned" int
    public void UnlockLevelPack(int index)
    {
        // Toggle on the bit at index
        // To toggle on use |=
        // To toggle off a bit use alt+94 then = (Example: ^= )
        state.levelPackOwned |= 1 << index;
    }

    //Reset the whole save file
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}
