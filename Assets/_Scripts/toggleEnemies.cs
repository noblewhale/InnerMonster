using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class toggleEnemies : MonoBehaviour 
{
    public static Dictionary<GameObject, GameObject> Enemies = new Dictionary<GameObject, GameObject>();

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {	

	}

    //public void addToEnemyArray(GameObject newEnemy)
    //{
    //    foreach (GameObject tempGameObject in Enemies.Keys)
    //    {
    //        tempGameObject.GetComponent<placeOnAllEnemies>().childSaneEnemy.gameObject.SetActive(false);
    //    }
    //}

    //public void removeFromEnemyArray(GameObject newEnemy)
    //{
    //    //Enemies.Remove(newEnemy);
    //    //for (int i = 0; i < Enemies.Count; i++)
    //    //{
    //    //    if ((Enemies[i] as GameObject) == newEnemy)
    //    //    {
    //    //        Enemies.RemoveAt(i);
    //    //        return;
    //    //    }
    //    //}
    //}
}
