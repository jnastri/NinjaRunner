using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color defaultColor;
    public Color selectedColor;
    private Material mat;

    Player playerClass;
    public GameObject playerObject;
    private SwipeControls swipeScript;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        swipeScript = GetComponent<SwipeControls>();
        playerClass = playerObject.GetComponent<Player>();
    }

    void OnTouchDown()
    {
        playerClass.jumpBool = true;
        Debug.Log("Pressed the button");
        mat.color = selectedColor;
    }
    void OnTouchUp()
    {
        Debug.Log("Released the button");
        mat.color = defaultColor;
    }
    void OnTouchStay()
    {
        Debug.Log("Button is still being pressed");


        mat.color = selectedColor;
    }
    void OnTouchExit()
    {
        Debug.Log("Button is pressed while not on button");
        mat.color = defaultColor;
    }
}
