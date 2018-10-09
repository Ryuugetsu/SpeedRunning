using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text score;       //get score text
    public UnityEngine.UI.Text highScore;   //get high score text

    // Use this for initialization
    void Start()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();    //set current score
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString(); // set high score 
        
    }
}

