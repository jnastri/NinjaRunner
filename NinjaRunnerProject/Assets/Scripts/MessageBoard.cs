using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoard : MonoBehaviour {

    private Text messageText;
    private Animator boardAnim;
    public Button okButton;


    // Use this for initialization
    void Start () {
        messageText = GetComponent<Text>();
        boardAnim = GetComponent<Animator>();
    }

    public void SendMessageBoard(string input)
    {
        messageText.text = input;
        boardAnim.SetBool("isOn", true);
        okButton.interactable = true;
    }

    public void ConfirmMessageButton()
    {
        okButton.interactable = false;
        boardAnim.SetBool("isOn", false);

        
    }
}
