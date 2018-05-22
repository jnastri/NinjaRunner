
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public string loadLevel;

    public void Start()
    {
        //FadeToLevel(loadLevel);
    }

    // Update is called once per frame
    void Update () {
        
	}


    public void FadeToLevel(string levelName)
    {
        loadLevel = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(loadLevel);
    }
}
