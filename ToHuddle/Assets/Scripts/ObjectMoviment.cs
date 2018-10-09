using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoviment : MonoBehaviour {

    public float speed;
    private float x;

    public GameObject player;       //get player gameobject
    private bool pass;  // variable to test if player pass by the obstacle

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;   
        x -= speed * Time.deltaTime; //increase gameobject speed
        transform.position = new Vector3(x, transform.position.y, transform.position.z); // apply speed on gameobject

        //destroy the gameObject after letf the Canvas
        if(transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }

        //test and increase score
        if(x < player.transform.position.x && !pass)
        {
            pass = true;
            Player.score += 10;
        }
	}
}
