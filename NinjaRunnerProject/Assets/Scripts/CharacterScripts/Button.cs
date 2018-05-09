using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color defaultColor;
    public Color selectedColor;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void OnTouchDown()
    {
        Debug.Log("Pressed the button");
        mat.color = selectedColor;
    }
    void OnTouchUp()
    {
        mat.color = defaultColor;
    }
    void OnTouchStay()
    {
        mat.color = selectedColor;
    }
    void OnTouchExit()
    {
        mat.color = defaultColor;
    }
}
