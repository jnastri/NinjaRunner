using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLevelChanger : MonoBehaviour {

    public GameObject levelChanger;
    [SerializeField]
    string levelName;

	// Use this for initialization
	void Start () {

        levelChanger = GameObject.Find("LevelChanger");

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            levelChanger.GetComponent<LevelChanger>().FadeToLevel(levelName);
        }
    }
}
