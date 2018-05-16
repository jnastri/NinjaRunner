using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeControls : MonoBehaviour {

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    public float swipeDistVertical;

    Player playerClass;
    public GameObject playerObject;

    public PanelScrolling panelScrolling;

    [SerializeField]
    private Scene activeScene;
    public string sceneName;

    


    private void Start()
    {

        //DetermineControls();


    }
    void Update()
    {

        DetermineControls();
        /*  if (sceneName == "MainMenu")
          {
              MainMenuControls();
          }

          else if (sceneName == "JR_Test")
          {
              LevelControls();
          } */
    }

    void MainMenuControls()
    {
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0) { }//up swipe

                        //Jump ();

                        else if (swipeValue < 0)
                        {

                        }//down swipe




                        //Shrink ();

                    }

                    else if (swipeDistVertical < minSwipeDistY)
                    {

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)
                        {

                            panelScrolling.touchLeft = true;
                            Debug.Log("Swiped Right");
                        }
                        //right swipe


                        //MoveRight ();

                        else if (swipeValue < 0)
                        {
                            panelScrolling.touchRight = true;
                            Debug.Log("Swiped Left");
                        }//left swipe

                        //MoveLeft ();

                    }
                    break;
            }
        }
    }
    void LevelControls()
    {
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0) { }//up swipe

                        //Jump ();

                        else if (swipeValue < 0)
                        {


                            playerClass.SlideController();
                        }//down swipe




                        //Shrink ();

                    }

                    else if (swipeDistVertical < minSwipeDistY)
                    {
                            playerClass.jumpBool = true;
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)
                        {
                        }
                        //right swipe


                        //MoveRight ();

                        else if (swipeValue < 0)
                        {
                        }//left swipe

                        //MoveLeft ();

                    }
                    break;
            }
        }
    }

    public string DetermineSceneType(string input)
    {
        return sceneName = input;


    }

    public void DetermineControls()
    {
        //activeScene = SceneManager.GetActiveScene();
        //sceneName = activeScene.name;
        if (sceneName == "Level")
        {
            playerClass = playerObject.GetComponent<Player>();
            panelScrolling = null;
            LevelControls();
        }

        else if (sceneName == "Menu")
        {
            playerClass = null;
            playerObject = null;
            panelScrolling = GetComponent<PanelScrolling>();
            MainMenuControls();
        }

    }
}
