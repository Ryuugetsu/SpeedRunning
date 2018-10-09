using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

    public GameObject barreiraPrefab;
    public float spawnRate;
    private float canSpawn = 0;
    private Vector3 position;
    public float posA;
    public float posB;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > canSpawn)
        {
            if(Random.Range(1,100) > 50)
            {
                position = new Vector3(transform.position.x, posA, transform.position.z);
            }
            else
            {
                position = new Vector3(transform.position.x, posB, transform.position.z);
            }
            Instantiate(barreiraPrefab, position, Quaternion.identity);
            canSpawn = Time.time + spawnRate;
        }
	}
}
