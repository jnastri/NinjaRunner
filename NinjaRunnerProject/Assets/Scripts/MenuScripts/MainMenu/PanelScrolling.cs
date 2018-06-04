using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PanelScrolling : MonoBehaviour
{
    public Transform[] menus;
    public float scrollSpeed = 5f;
    bool isRotatingRight;
    int rotationCount = 0;
    Transform newMenuLocation;
    Quaternion ogRot;
    public bool touchLeft;
    public bool touchRight;

    public GameObject rotateCube;
    public Transform rotateCubeTransform;
    public bool touchUp;
    public bool touchDown;
	// Use this for initialization
	void Start ()
    {
        ogRot = transform.rotation;
        newMenuLocation = menus[0];
        rotationCount = 0;
        rotateCubeTransform = rotateCube.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || touchLeft)
        {
            if (!Advertisement.isShowing)
            {
                print("Left " + rotationCount);
                DeterminehetherRotatingLeft();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || touchRight)
        {
            if (!Advertisement.isShowing)
            {
                print("Right " + rotationCount);
                DeterminehetherRotatingRight();
            }
        }
        RotateCam();
        touchLeft = false;
        touchRight = false;
    }

    void DeterminehetherRotatingRight()
    {
        isRotatingRight = true;
        if (rotationCount == 0)
        {
            transform.rotation = ogRot;
        }
        DetermineRotationDestination(rotationCount);
        rotationCount++;
        if (rotationCount >= 4)
        {
            rotationCount = 0;
        }
    }

    void DeterminehetherRotatingLeft()
    {
        isRotatingRight = false;
        if (rotationCount == 0)
        {
            transform.rotation = ogRot;
        }

        DetermineRotationDestination(rotationCount);
        rotationCount--;
        if (rotationCount <= -1)
        {
            rotationCount = 3;
        }
    }

    void DetermineRotationDestination(int caseNum)
    {
        switch (caseNum)
        {
            case 0:
                if (isRotatingRight)
                {
                    newMenuLocation = menus[1];
                }
                else
                {
                    newMenuLocation = menus[3];
                }
                break;
            case 1:
                if (isRotatingRight)
                {
                    newMenuLocation = menus[2];
                }
                else
                {
                    newMenuLocation = menus[0];
                }
                break;
            case 2:
                if (isRotatingRight)
                {
                    newMenuLocation = menus[3];
                }
                else
                {
                    newMenuLocation = menus[1];
                }
                break;
            case 3:
                if (isRotatingRight)
                {
                    newMenuLocation = menus[0];
                }
                else
                {
                    newMenuLocation = menus[2];
                }
                break;
            default:
                break;
        }
    }

    void RotateCam()
    {
        //transform.Rotate(Vector3.up, 90);
        transform.rotation = Quaternion.Lerp(transform.rotation, newMenuLocation.rotation, Time.deltaTime * scrollSpeed);
    }

    void RotateLevels()
    {
        if (touchUp)
        {

        }
    }
}
