using UnityEngine;
using System.Collections;

public class S_speedy : MonoBehaviour {
	
	private Transform target;
	private GameObject player;
	public float enemySpeed;
	public CharacterController control;
	private Vector3 move = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
		//Find the player and load their transforms.
		player = GameObject.Find ("Player");
		target = player.transform;	
		
		//Randomize maggot speed.
		enemySpeed += (Random.Range (-0.25f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(target);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (control.enabled)
        {
            control.SimpleMove(forward * enemySpeed);
        }
        this.gameObject.transform.rotation = Quaternion.Euler(0, this.gameObject.transform.rotation.y, 0);

	}
}
