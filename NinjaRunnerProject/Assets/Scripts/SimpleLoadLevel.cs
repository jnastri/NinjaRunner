using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLoadLevel : MonoBehaviour {

    public bool changeLevel;
    public string levelName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator ChangeLevel()
    {

            float fadeTime = GameObject.Find("SceneManagement").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            Debug.Log("Changing Scenes");
            SceneManager.LoadScene(levelName);
        
    }
}
