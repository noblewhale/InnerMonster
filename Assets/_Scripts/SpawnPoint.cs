using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public float initialSpawnTime;
    public GameObject spawnPrefab;
    float lastSpawnZeroTime = 0;
    public float reduceSpawnTimeByThisAmount;
    public float timePassedToReduceSpawnTime;

    float reduceSpawnTimerZeroTime;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("initial " + initialSpawnTime);
        if (Time.time - lastSpawnZeroTime > initialSpawnTime)
        {
            GameObject.Instantiate(spawnPrefab, this.gameObject.transform.position, Quaternion.identity);
            lastSpawnZeroTime = Time.time;
        }
        if (Time.time - reduceSpawnTimerZeroTime > timePassedToReduceSpawnTime)
        {
            reduceSpawnTimerZeroTime = Time.time;
            initialSpawnTime = initialSpawnTime - reduceSpawnTimeByThisAmount;
            if (initialSpawnTime <= 1)
            {
                initialSpawnTime = 1;
            }
        }
	}
}
