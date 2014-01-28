using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	//This is pretty much HUD elements and player health/energy.
	public GameObject player;
	
	//Player variables.
	private float playerHealth02;
	public float playerEnergy02;
	public bool discharged02;
	//public bool dead02;
	
	//GUI assets.
	//public Texture sidePanelBack;
	public Texture health00;
	public Texture health01;
	public Texture health02;
	public Texture health03;
	public Texture health04;
	public Texture health05;
	public Texture health06;
	//public Texture chargedBar;
	//public Texture dischargedBar;
	//public Texture energyBarBack;
	private float targetWidth = 1920;
	private float targetHeight = 1080;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealth02 = player.GetComponent<playerController>().playerHealth;
		playerEnergy02 = player.GetComponent<playerController>().playerEnergy;
		discharged02 = player.GetComponent<playerController>().discharged;
		//dead02 = player.GetComponent<playerController>().dead;
		
		
	}
	
	void OnGUI()
	{
		//Setup scale factors for GUI elements.
		float scaleWidth;
		scaleWidth = Screen.width/targetWidth;
		
		float scaleHeight;
		scaleHeight = Screen.height/targetHeight;
		
		//		//Side panel.
		//		GUI.DrawTexture(new Rect (0, 0, 312 * scaleWidth, 1080 * scaleHeight), sidePanelBack,ScaleMode.StretchToFill, true, 0);
		//		GUI.DrawTexture(new Rect (1920 * scaleWidth, 0, -312 * scaleWidth, 1080 * scaleHeight), sidePanelBack,ScaleMode.StretchToFill, true, 0);
		
		//Health dial.
		if (playerHealth02 >= 6)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health06, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 < 6)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health05, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 < 4)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health04, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 < 3)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health03, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 < 2)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health02, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 < 1)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health01, ScaleMode.StretchToFill, true, 0);
		if (playerHealth02 <= 0)
			GUI.DrawTexture(new Rect(53 * scaleWidth,53 * scaleHeight,400 * scaleWidth,400 * scaleHeight), health00, ScaleMode.StretchToFill, true, 0);
		
		//		// Energy bars.
		//		int energyInt = (int)playerEnergy02;
		//		
		//		if (discharged02 == false)
		//		{
		//			//Left side energy bar.
		//			GUI.DrawTexture(new Rect(96 * scaleWidth,340 * scaleHeight,40 * scaleWidth,400 * scaleHeight), energyBarBack, ScaleMode.StretchToFill, true, 0);
		//			GUI.DrawTexture(new Rect(96 * scaleWidth,740 * scaleHeight,40 * scaleWidth, energyInt * -4 * scaleHeight), chargedBar, ScaleMode.StretchToFill, true, 0);
		//			//Right side energy bar.
		//			GUI.DrawTexture(new Rect(1784 * scaleWidth,340 * scaleHeight,40 * scaleWidth,400 * scaleHeight), energyBarBack, ScaleMode.StretchToFill, true, 0);
		//			GUI.DrawTexture(new Rect(1784 * scaleWidth,740 * scaleHeight,40 * scaleWidth, energyInt * -4 * scaleHeight), chargedBar, ScaleMode.StretchToFill, true, 0);
		//		}
		//		
		//		if (discharged02 == true)
		//		{
		//			//Left side energy bar.
		//			//GUI.DrawTexture(new Rect(96 * scaleWidth,340 * scaleHeight,40 * scaleWidth,400 * scaleHeight), energyBarBack, ScaleMode.StretchToFill, true, 0);
		//			GUI.DrawTexture(new Rect(96 * scaleWidth,740 * scaleHeight,40 * scaleWidth, energyInt * -4 * scaleHeight), dischargedBar, ScaleMode.StretchToFill, true, 0);
		//			//Right side energy bar.
		//			//GUI.DrawTexture(new Rect(1784 * scaleWidth,340 * scaleHeight,40 * scaleWidth,400 * scaleHeight), energyBarBack, ScaleMode.StretchToFill, true, 0);
		//			GUI.DrawTexture(new Rect(1784 * scaleWidth,740 * scaleHeight,40 * scaleWidth, energyInt * -4 * scaleHeight), dischargedBar, ScaleMode.StretchToFill, true, 0);
		//		}
	}
}