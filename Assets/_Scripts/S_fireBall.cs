using UnityEngine;
using System.Collections;

public class S_fireBall : MonoBehaviour 
{
	public float fireBallSpeed;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//Moves fireball.
		float amtToMove = fireBallSpeed * Time.deltaTime;
		transform.Translate(Vector3.forward * amtToMove);
	
	}
	
		void OnBecameInvisible() 
	{
        Destroy(gameObject);
    }
}
