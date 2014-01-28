using UnityEngine;
using System.Collections;

public class playerProjectile : MonoBehaviour {
	
	public float projectileSpeed;
	public float projectileDamage;
	public AudioClip shieldHit;
	public AudioClip enemyHit;
			
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Moves projectile.
		float amtToMove = projectileSpeed * Time.deltaTime;
		transform.Translate(Vector3.forward * amtToMove);
	}
	
	
	//Damages enemies when projectile hits them.
	void OnTriggerEnter (Collider other)
	{	
		
		if (other.gameObject.tag == "barrier")
		{
			Destroy(gameObject);				
		}
		
		//Shielded enemies are protected unless bullet is charged to the max level.		
		if (other.gameObject.tag == "shielded")
		{
			
			if (transform.localScale == new Vector3(0.8f, 0.8f, 0.8f))
			{
				AudioSource.PlayClipAtPoint(enemyHit, transform.position);
				Destroy (other.gameObject);	
				Destroy (gameObject);
			}
				
			else
			{
				AudioSource.PlayClipAtPoint(shieldHit, transform.position);
				Destroy(gameObject);	
			}			
		}
		

		
		//Calculate enemy hits and inflict damage on enemies.
		if (other.gameObject.tag == "enemy")
		{
			AudioSource.PlayClipAtPoint(enemyHit, transform.position);
			
			if (transform.localScale == new Vector3(0.8f, 0.8f, 0.8f))
			{
				projectileDamage = 3f;	
			}
		
			else if (transform.localScale == new Vector3(0.5f, 0.5f, 0.5f))
			{
				projectileDamage = 2f;
				Destroy(gameObject);	
			}
			
			else if (transform.localScale == new Vector3(0.2f, 0.2f, 0.2f))
			{
				projectileDamage = 1f;
				Destroy(gameObject);
			}
			
			else
			{
				projectileDamage = 1f;
				Destroy(gameObject);
			}
			
			other.gameObject.GetComponent<S_enemyLevel>().enemyHealth -= projectileDamage;
		}	
		

	}
	
	
	
	void OnBecameInvisible() 
	{
        Destroy(gameObject);
    }
}
