using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour {

    public GameObject cameraObject;
    public Scene currentScene;
    Scene activeScene;

	// Use this for initialization
	void Start () {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        SendSceneMessage();


    }


    void SendSceneMessage()
    {

        if (cameraObject.name.Contains("Level"))
        {
            cameraObject.SendMessage("DetermineSceneType", "Level");
        }

        else if (cameraObject.name.Contains("Menu"))
        {
            cameraObject.SendMessage("DetermineSceneType", "Menu");
        }
    }
}
