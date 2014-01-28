using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
	//Player variables.
	public float playerHealth;
	public float playerEnergy;
	public float energyRate;
	public bool discharged;
	public bool dead;
	
	//Movement variables.
	public float defaultSpeed;
	public float boostSpeed;
	public float boostDrain;
	private Vector3 move = Vector3.zero;
	public CharacterController control;
	private Vector3 startPosition;
	private float activateBoost;
	private float HorizontalMove;
	private float VerticalMove;
	private float playerSpeed;
	
	//Projectile variables;
	public GameObject playerProjectile;
	public float bulletOffset;
	public float bulletHeight;
	public float bulletSidePos;
	public float chargeSpeed;
	public float chargeLevel;
	public float chargeLimit;
	public float chargeDamage;
	
	public togglePsychosis togglePsychosisScript;
	//    public HingeJoint hinge;
	//    JointMotor motor;
	
	public GameObject basicAttackSphere;
	float basicAttackSphereRadius;
	
	public float basicAttackDamage;
	public float surroundingAttackDamage;
	public float chargedAttackDamage;
	
	public float incomingProjectileDamage;
	
	public GameObject surroundingAttackSphere;
	float surroundingAttackSphereRadius;
	
	
	public GameObject dashSphere1;
	public GameObject dashSphere2;
	
	float swingSwordZeroTime = 999999999999999999;
	
	
	public bool twinStick;
	
	bool canTakeDamage = true;
	
	float startingEnergyRate;
	
	bool canMove = true;
	bool doChargedAttackDamage = false;
	
	float surroundingAttackSphereHeight;
	
	bool doOnce = true;
	
	public int killCount = 0;

    public GameObject newsPaper;
	
	
	void Awake()
	{
		//        hinge = GetComponent<HingeJoint>();
		//        motor = hinge.motor;
		//motor.targetVelocity = 10.0f;
	}
	// Use this for initialization
	void Start () 
	{
		surroundingAttackSphereHeight = surroundingAttackSphere.transform.position.y;
		startingEnergyRate = energyRate;
		//hinge = this.gameObject.GetComponent<HingeJoint>();
		control = GetComponent<CharacterController>();
		startPosition = transform.position;
		basicAttackSphereRadius = basicAttackSphere.GetComponent<SphereCollider>().radius * surroundingAttackSphere.transform.position.x;
		surroundingAttackSphereRadius = surroundingAttackSphere.GetComponent<SphereCollider>().radius * surroundingAttackSphere.transform.position.x;
		
	}
	
	void swingSword()
	{
		Debug.Log("swingSword");
		if (Time.time - swingSwordZeroTime > .5f)
		{
			Debug.Log("MASSIVEATTACK!");
			doChargedAttackDamage = true;
			//lunge forward
			//canMove = false;
		}
		Collider[] hitColliders = Physics.OverlapSphere(basicAttackSphere.transform.position, basicAttackSphereRadius);
		int i = 0;
		while (i < hitColliders.Length)
		{
			//Debug.Log("hitcollider");
			if (hitColliders[i].gameObject && hitColliders[i].gameObject.GetComponent<S_enemyLevel>())
			{
				Debug.Log("dmg");
				if (doChargedAttackDamage)
				{
					hitColliders[i].gameObject.GetComponent<S_enemyLevel>().enemyHealth -= chargedAttackDamage;
				}
				else
				{
					hitColliders[i].gameObject.GetComponent<S_enemyLevel>().enemyHealth -= basicAttackDamage;
				}
			}
			i++;
		}
		//Debug.Log("swingsowrd");
		//motor.force = 100;
		//motor.targetVelocity = 100.0f;
		//gameObject.GetComponent<HingeJoint>().motor = this.motor;
		//hinge.motor.force = 100;
	}
	
	void surroundingAttack()
	{
		Debug.Log("surroundingAttack");
		Collider[] hitColliders = Physics.OverlapSphere(surroundingAttackSphere.transform.position, surroundingAttackSphereRadius);
		int i = 0;
		while (i < hitColliders.Length)
		{
			if (hitColliders[i].gameObject.GetComponent<S_enemyLevel>())
			{
				Debug.Log("surDmg");
				hitColliders[i].gameObject.GetComponent<S_enemyLevel>().enemyHealth -= surroundingAttackDamage;
			}
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("hor " + Input.GetAxisRaw("Horizontal"));
		//Debug.Log("vert " + Input.GetAxisRaw("Vertical"));
		//Debug.Log ("axis " + Input.GetAxis("Horizontal"));
		surroundingAttackSphere.transform.position = new Vector3(this.transform.position.x, surroundingAttackSphereHeight, this.transform.position.z);
		
		//if (Input.GetAxis("Horizontal") > .2f || Input.GetAxis("Horizontal") < -.2f || Input.GetAxis("Vertical") > .2f || Input.GetAxis("Vertical") < -.2f)
		//{
		//    basicAttackSphere.transform.position = this.transform.position + new Vector3(Input.GetAxis("Horizontal") * 1.5f, .4f, Input.GetAxis("Vertical") * 1.5f);
		//    dashSphere1.transform.position = this.transform.position + new Vector3(Input.GetAxis("Horizontal") * 3f, .4f, Input.GetAxis("Vertical") * 3f);
		//    dashSphere2.transform.position = this.transform.position + new Vector3(Input.GetAxis("Horizontal") * 4.5f, .4f, Input.GetAxis("Vertical") * 4.5f);
		//}
		if (twinStick)
		{
			//if (Input.GetAxis("ArrowHorizontal") > .2f || Input.GetAxis("ArrowHorizontal") < -.2f || Input.GetAxis("ArrowVertical") > .2f || Input.GetAxis("ArrowVertical") < -.2f)
			{
				Vector3 normalizedAimingVector = Vector3.Normalize(new Vector3(Input.GetAxis("ArrowHorizontal"), 0, Input.GetAxis("ArrowVertical")));
				basicAttackSphere.transform.position = this.transform.position + new Vector3(normalizedAimingVector.x * 1.5f, -1.0f, normalizedAimingVector.z * 1.5f);
				dashSphere1.transform.position = this.transform.position + new Vector3(normalizedAimingVector.x * 3.5f, -1.0f, normalizedAimingVector.z * 2.5f);
				dashSphere2.transform.position = this.transform.position + new Vector3(normalizedAimingVector.x * 5.5f, -1.0f, normalizedAimingVector.z * 3.5f);
			}
		}
		//posTemp.Set (Input.GetAxis ("Horizontal") * 1.25f, Input.GetAxis ("Vertical") * 1.25f);
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//    swingSwordZeroTime = Time.time;
		//    //swingSword();
		//}
		//if (Input.GetKeyUp(KeyCode.Space))
		//{
		//    swingSword();
		//}
		if (Input.GetButtonDown("SurroundingAttack"))
		{
			surroundingAttack();
		}
		if (Input.GetButtonDown("BasicAttack"))
		{
			swingSwordZeroTime = Time.time;
			//canMove = false;
			//swingSword();
		}
		if (Time.time - swingSwordZeroTime > .2f)
		{
			canMove = false;
		}
		if (Input.GetButtonUp("BasicAttack"))
		{
			canMove = true;
			swingSword();
			swingSwordZeroTime = 9999999999999;
		}
		
		Vector3 angleVector = Vector3.Normalize(new Vector3(Input.GetAxis("ArrowHorizontal"), 0, Input.GetAxis("ArrowVertical")));
		
		//Quaternion targetRotation = Quaternion.LookRotation (basicAttackSphere.transform.position - transform.position);
		
		//str = Mathf.Min (strength * Time.deltaTime, 1);
		
		//Vector3 point = basicAttackSphere.transform.position;
		
		//point.x = 270f;
		//point.z = 0.0f;
		
		//transform.LookAt(point, Vector3.back);
		//transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 5);
		
		
		float newAngle = Vector3.Angle(Vector3.forward, angleVector);
		//Debug.Log("newAngle " + newAngle);
		if (basicAttackSphere.transform.position.x < this.transform.position.x)
		{
			this.transform.eulerAngles = (new Vector3(270, -newAngle, 0));
			//Debug.Log ("1");
		}
		else if (basicAttackSphere.transform.position.x > this.transform.position.x)
		{
			//Debug.Log ("2");
			this.transform.eulerAngles = (new Vector3(270, newAngle, 0));
		}
		else if (newAngle == 0)
		{
			//Debug.Log ("3");
			this.transform.eulerAngles = (new Vector3(270, 0, 0));
		}
		else if (newAngle == 180)
		{
			//Debug.Log ("4");
			this.transform.eulerAngles = (new Vector3(270, 180, 0));
		}
		
		//Set player energy range and recharge rate.
		playerEnergy = Mathf.Clamp (playerEnergy, 0, startingEnergyRate);
		playerEnergy += Time.deltaTime * energyRate;
		
		if (playerEnergy <= 1)
			discharged = true;
		
		if (playerEnergy >= startingEnergyRate)
			discharged = false;
		
		#region Movement 
		
		if (dead == false)
		{
			//Controls movement.
			
			//Boost.
			activateBoost = Input.GetAxis("Boost");
			
			if (activateBoost < -0.1f  && discharged == false || activateBoost > 0.1f && discharged == false)
			{
				doOnce = true;
				foreach (GameObject tempGameObject in toggleEnemies.Enemies.Keys)
				{
					if (tempGameObject == true)
					{
						//doOnce = true;
						tempGameObject.GetComponent<CharacterController>().enabled = false;
						tempGameObject.collider.enabled = false;
						//tempGameObject.renderer.enabled = false;
						//tempGameObject.GetComponent<placeOnAllEnemies>().childSaneEnemy.renderer.enabled = true;
					}
				}
				canTakeDamage = false;
				playerSpeed = boostSpeed;
				playerEnergy -= Time.deltaTime * boostDrain;
			}
			else if (doOnce && activateBoost > -0.1f && activateBoost < 0.1f || discharged == true)
			{
				doOnce = false;
				foreach (GameObject tempGameObject in toggleEnemies.Enemies.Keys)
				{
					if (tempGameObject == true)
					{
						tempGameObject.GetComponent<CharacterController>().enabled = true;
						tempGameObject.collider.enabled = true;
						//tempGameObject.renderer.enabled = false;
						//tempGameObject.GetComponent<placeOnAllEnemies>().childSaneEnemy.renderer.enabled = true;
					}
				}
				canTakeDamage = true;
				playerSpeed = defaultSpeed;
			}
			
			
			if (canMove)
			{
				//Movement.
				move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
				//if (move.magnitude > .6f)//not needed?
				{
					move.Normalize();
					//move = Vector3.Normalize(move) * Time.deltaTime;
					control.SimpleMove(move * playerSpeed * Time.deltaTime);
				}
			}
			
			
			//Charges Projectile.
			if (Input.GetButton("ForwardFire") && chargeLevel < chargeLimit)	
			{	
				chargeLevel += Time.deltaTime * chargeSpeed;
			}
			
			else if (Input.GetButton("LeftFire") && chargeLevel < chargeLimit)	
			{	
				chargeLevel += Time.deltaTime * chargeSpeed;
			}
			
			else if (Input.GetButton("RightFire") && chargeLevel < chargeLimit)	
			{	
				chargeLevel += Time.deltaTime * chargeSpeed;
			}
			
			else if (Input.GetButton("BackFire") && chargeLevel < chargeLimit)	
			{	
				chargeLevel += Time.deltaTime * chargeSpeed;
			}
		}
		#endregion
		
		#region Projectiles
		if (dead == false)
		{
			//Fires projectile.
			//Forward fire.
			if (Input.GetButtonUp("ForwardFire") && discharged == false)
			{                                                                               
				Vector3 position = new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z + bulletOffset);
				
				projectileFire();
				
				Instantiate(playerProjectile, position, Quaternion.identity);	
				
				projectileReset();
			}
			
			//Left fire.
			else if (Input.GetButtonUp("LeftFire") && discharged == false)
			{                                                                               
				Vector3 position = new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z + bulletOffset);
				
				projectileFire();
				
				Instantiate(playerProjectile, position, Quaternion.LookRotation(Vector3.left, Vector3.up));	
				
				projectileReset();
			}                                                         //Ammount to offset bullets.
			
			//Right fire.
			else if (Input.GetButtonUp("RightFire") && discharged == false)
			{                                                                               //Ammount to offset bullets.
				Vector3 position = new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z+ bulletOffset);
				
				projectileFire();
				
				Instantiate(playerProjectile, position, Quaternion.LookRotation(Vector3.right, Vector3.up));	
				
				projectileReset();
			}
			
			//Back fire.
			else if (Input.GetButtonUp("BackFire") && discharged == false)
			{   Vector3 position = new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z + bulletOffset);
				
				projectileFire();
				
				Instantiate(playerProjectile, position, Quaternion.LookRotation(Vector3.back, Vector3.up));	
				
				projectileReset();
			}
		}
		
		
	}
	
	void projectileFire()
	{
		if(chargeLevel > 2f && discharged == false)
		{
			chargeDamage = 3f;
			playerProjectile.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			playerProjectile.audio.pitch = 0.75f;
			playerProjectile.audio.volume = 1f;
			playerEnergy -= 40;
		}
		
		else if (chargeLevel > 0.75f && discharged == false)
		{
			chargeDamage = 2f;
			playerProjectile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			playerProjectile.audio.pitch = 1f;
			playerProjectile.audio.volume = 0.75f;
			playerEnergy -= 20;
		}	
		
		else if (chargeLevel > 0f && discharged == false)
		{
			chargeDamage = 1f;
			playerProjectile.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			playerProjectile.audio.pitch = 1.25f;
			playerProjectile.audio.volume = .5f;
			playerEnergy -= 3;
		}
		
		
	}
	
	void projectileReset()
	{
		playerProjectile.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		chargeLevel = 0f;
		playerProjectile.audio.pitch = 1.25f;
		playerProjectile.audio.volume = 0.5f;
	}
	
	#endregion
	
	IEnumerator attackCoroutine(Collider other)
	{
		other.gameObject.GetComponent<S_enemyLevel>().enemyTouchAttackColliderAfterWithinRange.enabled = false;
		other.gameObject.GetComponent<CharacterController>().enabled = false;
		other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
		yield return new WaitForSeconds(1.0f);
		other.gameObject.GetComponent<CharacterController>().enabled = true;
		other.gameObject.GetComponent<CapsuleCollider>().enabled = true;
		//other.collider.enabled = true;
	}
	
	void OnTriggerEnter (Collider other)
	{
		//if (other.collider.GetType())
		//{
		
		//}
		//If player gets hit by an enemy.
		if (other.gameObject.tag == "enemy")
		{
			StartCoroutine(attackCoroutine(other));
			if (canTakeDamage)
			{
				Debug.Log("tookDmG");
				togglePsychosisScript.switchPhyschosis();
				float damage = other.gameObject.GetComponent<S_enemyLevel>().enemyAttack;
				playerHealth -= damage;
			}
			if (playerHealth <= 0)
			{
				StartCoroutine(destroyMech());
			}
		}
		
		
		
		if (other.gameObject.tag == "eProjectile")
		{
			if (canTakeDamage)
			{
				Debug.Log("tookDmG");
				togglePsychosisScript.switchPhyschosis();
				playerHealth -= incomingProjectileDamage;
			}
			if (playerHealth <= 0)
				StartCoroutine(destroyMech());
		}
		
	}
	
	void OnCollisionEnter (Collision other)
	{
		// Debug.Log("isHappening");
		//If player gets hit by an enemy.
		//if (other.gameObject.tag == "enemy")
		//{
		//    if (canTakeDamage)
		//    {
		//        togglePsychosisScript.switchPhyschosis();
		//        //Debug.Log("isHappening");
		//        float damage = other.gameObject.GetComponent<S_enemyLevel>().enemyAttack;
		//        playerHealth -= damage;
		//    }
		//    if (playerHealth <= 0)
		//        StartCoroutine(destroyMech());
		//}
		
		
		
		//if (other.gameObject.tag == "eProjectile")
		//{
		//    if (canTakeDamage)
		//    {
		//        togglePsychosisScript.switchPhyschosis();
		//        //Debug.Log("isHappening22");
		//        playerHealth--;
		//    }
		//    if (playerHealth <= 0)
		//        StartCoroutine(destroyMech());
		//}
		
	}


    IEnumerator destroyMech()
    {
        newsPaper.gameObject.SetActive(true);
        gameObject.renderer.enabled = false;
        //this.gameObject.renderer.enabled = false;
        //knightRenderer.renderer.enabled = false;
        transform.position = startPosition;
        dead = true;
        Time.timeScale = .5f;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }
}
