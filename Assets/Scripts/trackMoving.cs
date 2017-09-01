using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trackMoving : MonoBehaviour {

    public float trackSpeed;
    Vector2 offset;
    
	void Start () {
		
	}
	void Update () {
        offset = new Vector2(0, Time.time * trackSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
