using UnityEngine;
using System.Collections;

public class placeOnAllEnemies : MonoBehaviour 
{
    public GameObject childSaneEnemy;
	// Use this for initialization
    void Start()
    {
        toggleEnemies.Enemies.Add(this.gameObject, this.gameObject);
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
