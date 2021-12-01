using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using UnityEngine.Networking;

public class TextPresentationEnd : TextPresentation
{
	//better enum
	[HideInInspector]
	public string userName;
	[HideInInspector]
	public string userEmail;
	[HideInInspector]
	public string userBirthDay;

	[Header("Forms and Button")]
	public GameObject forms;
	public GameObject retryButton;

	[Header("Input fields")]
	public TMP_InputField nameInputField;
	public TMP_InputField emailInputField;
	public TMP_InputField birthInputField;

	private TouchScreenKeyboard keyboard;
	private string meTheAutor = "guilherme";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayText(displayTexts));
    }

    // Update is called once per frame
    void Update()
    {
        if(textPresentationEnd){
        	textDisplay.text = "";
        	textPresentationEnd = false;
            retryButton.SetActive(true);
        }
    }

    public void openKeyboard(){
    	keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);	
    }

    public void closeKeyboard(){
    	keyboard.active = false;
    }

    public void retry(){
		SceneManager.LoadScene("Game");
    }
}

