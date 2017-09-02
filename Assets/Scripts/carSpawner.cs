using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    public float limitBoundary = 2.14f;
    float timer;
    public float delayTimer = 2f;
	void Start () {
        timer = delayTimer;
	}
	void Update () {
        timer -= Time.deltaTime;
        carNo = Random.Range(0, 5);
        if (timer <= 0)
        {
            Vector3 enemyCarPos = new Vector3(Random.Range(-limitBoundary, limitBoundary), transform.position.y, transform.position.z);
            Instantiate(cars[carNo], enemyCarPos, transform.rotation);
            timer = delayTimer;
        }
       
	}
}
