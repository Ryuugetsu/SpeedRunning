using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    [SerializeField] private GameObject quit;

    // Use this for initialization
    void Start () {
        quit.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
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

            if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2); //change to fase 1 scene
        }	
	}
}
