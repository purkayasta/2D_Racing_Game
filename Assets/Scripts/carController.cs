﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour 
{
    public AudioManager am;
    public float carSpeed;
    Vector3 carPosition;
    public float limitBoundary = 2.14f;
    public UiManager ui;
	void Start () 
    {
        carPosition = transform.position;
        am.gameOver.Stop();
        am.carSound.Play();
	}
	void Update () 
    {
        carPosition.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        carPosition.x = Mathf.Clamp(carPosition.x, -limitBoundary, limitBoundary);
        transform.position = carPosition;
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            ui.gameOverAction();
            am.carSound.Stop();
            am.gameOver.Play();
        }
            
    }﻿
}
