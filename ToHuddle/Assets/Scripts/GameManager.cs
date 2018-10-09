using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject quit;
    private bool canIncrease = true;    //variable to work the timeScale

	// Use this for initialization
	void Start () {
        Time.timeScale = 1; //set default timeScale
        quit.SetActive(false);

    }

    // Update is called once per frame
    void Update () {

        //Quit
        if (Input.GetButtonDown("Cancel"))
        {

            if (!quit.activeInHierarchy)
            {
                quit.SetActive(true);
            }
            else
            {
                quit.SetActive(false);
            }
        }
        if (Input.GetButtonDown("Submit") && quit.activeInHierarchy)
        {
            Application.Quit();
            Debug.Log("fechou");
        }


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
