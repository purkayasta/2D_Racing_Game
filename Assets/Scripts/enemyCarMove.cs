using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCarMove : MonoBehaviour {

    public float carSpeed = 4f;
	void Start () {
		
	}
	void Update () {
        transform.Translate(new Vector3(0, 1, 0) * carSpeed * Time.deltaTime);
	}
}
