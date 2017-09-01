using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

    public GameObject car;
    public float limitBoundary = 2.14f;
    float timer;
    float delayTimer = 2f;
	void Start () {
        timer = delayTimer;
	}
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 enemyCarPos = new Vector3(Random.Range(-limitBoundary, limitBoundary), transform.position.y, transform.position.z);
            Instantiate(car, enemyCarPos, transform.rotation);
            timer = delayTimer;
        }
       
	}
}
