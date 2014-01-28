using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private string menuText = "Gomorrah:\nHell to Pay\n\nMain Menu";
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(50, 50, 200, 200), menuText);
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2,	Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), "New Game"))
		{
			Application.LoadLevel(1);
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2,	Screen.height / 2 + (buttonHeight) / 2, buttonWidth, buttonHeight), "Continue"))
		{
			
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2,	Screen.height / 2 + (buttonHeight * 3) / 2, buttonWidth, buttonHeight), "Demonicon"))
		{
			
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2,	Screen.height / 2 + (buttonHeight * 5) / 2, buttonWidth, buttonHeight), "Exit"))
		{
			Application.Quit();
		}
	}
}
