using UnityEngine;
using System.Collections;

public class S_camera : MonoBehaviour 
{
	public GameObject playerTarget;
    public float damping = 1;
	Vector3 offset;

    public playerController playerScript;
	
	
	// Use this for initialization
	void Start () 
	{
	
		offset = transform.position - playerTarget.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void LateUpdate() 
	{
		
	    Vector3 desiredPosition = playerTarget.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;
        		
	}

    void OnGUI()
    {
        GUI.Button(new Rect(Screen.width - Screen.width / 9, 47, 60, 40), "Health " + playerScript.playerHealth.ToString());
        GUI.Button(new Rect(Screen.width - Screen.width  / 9, 5, 60, 40), "Kills " + playerScript.killCount.ToString());
    }
}
