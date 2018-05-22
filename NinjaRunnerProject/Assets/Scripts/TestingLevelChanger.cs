using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLevelChanger : MonoBehaviour {

    public GameObject levelChanger;
    [SerializeField]
    string levelName;
    [SerializeField]
    bool isOnClick;

	// Use this for initialization
	void Start () {

        levelChanger = GameObject.Find("LevelChanger");

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && isOnClick)
        {
            levelChanger.GetComponent<LevelChanger>().FadeToLevel(levelName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOnClick && collision.tag == "Player")
        {
            levelChanger.GetComponent<LevelChanger>().FadeToLevel("GameOver");
        }
    }
}
