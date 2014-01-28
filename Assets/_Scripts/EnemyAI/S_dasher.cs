using UnityEngine;
using System.Collections;

public class S_dasher : MonoBehaviour {
	
	//Positions and targets.
	private Transform target;
	private Vector3 startPosition;
	private GameObject player;
	private Vector3 targetPoint;
    private Quaternion targetRotation;
	//Speeds and timing and movement.
	private float speed;
	public float turnSpeed;
	public float normalSpeed;
	public float dashSpeed;
	public float dashTime;
	public CharacterController control;
	//Distances and ranges.
	public float awakeRange;
	public float attackRange;
	private Vector3 targetRelative;
	float distance;
	//Three different states.
	private bool idle;
	private bool awake;
	private bool attack;
	
	
	// Use this for initialization
	void Start () 
	{
		//Find the player and load their transforms.
		player = GameObject.Find ("Player");
		target = player.transform;
		
		//Record enemies start position so they can return.
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Find player's range.
		targetRelative = target.InverseTransformPoint(transform.position);
		distance = Vector3.Distance(transform.position,target.position);
		
		//Set up parameters for three diffferent states based on player's range.
		if(distance > awakeRange)
			idle = true;
		
		if(distance < awakeRange)
			idle = false;
		
		if(distance < awakeRange && distance > attackRange)
			awake = true;
		
		if (distance > awakeRange || distance < attackRange)
			awake = false;
		
		if(distance < attackRange)
			attack = true;
		
		if(distance > attackRange)
			attack = false;
		
		//When enemy is awake it moves toward the player.
		if (awake == true)
		{
			//Rotate Horn Head to look at player.
			targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
       		targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
       		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
			
			//Move Horn Head toward the player at normal speed.
			Vector3 forward = transform.TransformDirection(Vector3.back);
			
			speed = normalSpeed;
			control.SimpleMove(forward * speed);
		}
		

		//When enemy is idle in returns to idle animation.
		if (idle == true)
		{
			//Return HornHead back to original position.
       		if (transform.position != startPosition)
			{
				Vector3 forward = transform.TransformDirection(Vector3.forward);
				targetRotation = Quaternion.LookRotation (startPosition - transform.position, Vector3.up);
	       		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
				
				speed = normalSpeed;
				control.SimpleMove(forward * speed);
			}		
		}
		
		//When player is in range, enemy will attack the player.
		if (attack == true)
		{
			StartCoroutine(hornDash());
		}

        //this.gameObject.transform.rotation = Quaternion.Euler(0, this.gameObject.transform.rotation.y, 0);
		
	}
	
	IEnumerator hornDash()
	{
		Vector3 forward = transform.TransformDirection(Vector3.back);
		yield return new WaitForSeconds(dashTime);
		speed = dashSpeed;
		control.SimpleMove(forward * speed);
		
	}
	
}
