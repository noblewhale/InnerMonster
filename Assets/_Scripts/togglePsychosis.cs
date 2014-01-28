using UnityEngine;
using System.Collections;

public class togglePsychosis : MonoBehaviour 
{
    public GameObject crazyLand;
    public GameObject saneLand;

    public float freakOutTime;

    bool shouldMicroPause = true;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator freakOut()
    {
        //foreach (GameObject tempGameObject in toggleEnemies.Enemies.Keys)
        //{
        //    if (tempGameObject == true)
        //    {
        //        //tempGameObject.renderer.enabled = false;
        //        //enable to turn back enemy transformation on
        //        //tempGameObject.GetComponent<placeOnAllEnemies>().childSaneEnemy.renderer.enabled = true;
        //    }
        //}
        crazyLand.gameObject.SetActive(false);
        saneLand.gameObject.SetActive(true);
        yield return new WaitForSeconds(freakOutTime);
        saneLand.gameObject.SetActive(false);
        crazyLand.gameObject.SetActive(true);
        //foreach (GameObject tempGameObject in toggleEnemies.Enemies.Keys)
        //{
        //    if (tempGameObject == true)
        //    {
        //        //enable to turn back on enemy transformation
        //        //tempGameObject.GetComponent<placeOnAllEnemies>().childSaneEnemy.renderer.enabled = false;
        //        //tempGameObject.renderer.enabled = true;
        //    }
        //}
    }

    public void switchPhyschosis()
    {
        StartCoroutine(freakOut());
        if (shouldMicroPause)
        {
            //StartCoroutine(microPause());
        }
    }

    IEnumerator microPause()
    {
        Time.timeScale = .01f;
        shouldMicroPause = false;
        yield return new WaitForSeconds(.005f);
        Time.timeScale = 1f;
        shouldMicroPause = true;
    }
}
