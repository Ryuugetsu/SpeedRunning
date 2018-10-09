using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool canIncrease = true;    //variable to work the timeScale

	// Use this for initialization
	void Start () {
        Time.timeScale = 1; //set default timeScale
	}
	
	// Update is called once per frame
	void Update () {
        
        //TimeScale increase logic
        if (canIncrease)
        {
            Time.timeScale += 0.03f;
            canIncrease = false;
            StartCoroutine(TimeScale());
        }
	}

    //timeScale increase cooldown
    IEnumerator TimeScale()
    {
        yield return new WaitForSeconds(1);
        canIncrease = true;        
    }
}
