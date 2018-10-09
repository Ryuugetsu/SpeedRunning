using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;



public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text score;       //get score text
    public UnityEngine.UI.Text highScore;   //get high score text
    [SerializeField] private GameObject quit;

    // Use this for initialization
    void Start()
    {
        quit.SetActive(false);
        score.text = PlayerPrefs.GetInt("Score").ToString();    //set current score
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString(); // set high score 

        StartCoroutine(Upload());
    }

    private void Update()
    {
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
    }


    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("score", PlayerPrefs.GetInt("Score").ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://us-central1-huddle-team.cloudfunctions.net/api/memory/brunotavaresmarinho26@gmail.com", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

