using UnityEngine;
using System.Collections;

public class S_enemyLevel : MonoBehaviour {

	public float enemyHealth;
	public float enemyAttack;

    public playerController playerScript;

    public CapsuleCollider enemyTouchAttackColliderAfterWithinRange;
		
	// Use this for initialization
	void Start () 
	{
        enemyTouchAttackColliderAfterWithinRange = GetComponent<CapsuleCollider>();
        playerScript = GameObject.FindObjectOfType<playerController>().GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHealth <= 0f)
		{
            playerScript.killCount++;
			Destroy(gameObject);
		}
	}
	
}
