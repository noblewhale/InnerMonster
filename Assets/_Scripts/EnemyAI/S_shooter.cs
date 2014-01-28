using UnityEngine;
using System.Collections;

public class S_shooter : MonoBehaviour {

	public float enemySpeed;
	public CharacterController control;
	private Vector3 move = Vector3.zero;

	//Positions and targets.
	public Transform target;
	public GameObject player;
	//Turret parameters.
	public float turretSpeed;
	public float fireRate;
	public float fireBallHeight;
	public float flareSpeed;
	//Fireball and audio objects.
	public GameObject fireBall;
	public AudioClip loading;
	public AudioClip shooting;
	//Distances and ranges.
	public float range;
	float distance;
	//float fireTimer;
	private float lastShotTime = float.MinValue;
	
	// Use this for initialization
	void Start () 
	{
		//Find the player and load their transforms.
		player = GameObject.Find ("Player");
		target = player.transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Rotate turret to look at player.
		Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos); 
       	rotation.x=0;
       	rotation.z=0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turretSpeed);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		control.SimpleMove(forward * enemySpeed);
		//Fire at player when in range.
		distance = Vector3.Distance(transform.position,target.position);
		
		//Adjust fire rate to keep firing at player while in range.
		if(distance < range && Time.time > lastShotTime + (3.0f / fireRate))
		{
			lastShotTime = Time.time;
			
			StartCoroutine(launchFireBall());
		}
        //this.gameObject.transform.rotation = Quaternion.Euler(0, this.gameObject.transform.rotation.y, 0);
	}
	
	//Fire at player.
	IEnumerator launchFireBall()
    {
		audio.PlayOneShot(loading);
		
		yield return new WaitForSeconds(0.5f);
		
		Vector3 position = new Vector3(transform.position.x, transform.position.y + fireBallHeight, transform.position.z);
		Instantiate(fireBall, position, transform.rotation);
		audio.PlayOneShot(shooting);

	}
}
