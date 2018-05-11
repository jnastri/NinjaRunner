﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour {

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    public float swipeDistVertical;

    Player playerClass;
    public GameObject playerObject;


    private void Start()
    {
        playerClass = playerObject.GetComponent<Player>();
    }
    void Update()
    {
        //#if UNITY_ANDROID
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

                        else if (swipeValue < 0) {
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

                        if (swipeValue > 0) { }//right swipe

                        //MoveRight ();

                        else if (swipeValue < 0) { }//left swipe

                            //MoveLeft ();

                    }
                    break;
            }
        }
    }
}
