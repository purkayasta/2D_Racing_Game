using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour 
{
    public AudioManager am;
    public float carSpeed;
    Vector3 carPosition;
    public float limitBoundary = 2.14f;
    public UiManager ui;
    bool currentPlatformisAndroid = false;
    Rigidbody2D r;
	void Start () 
    {
        #if UNITY_ANDROID
            currentPlatformisAndroid = true;
            Debug.Log("Android");
        #else
            currentPlatformisAndroid = false;
            Debug.Log("Windows");
        #endif

        carPosition = transform.position;
        am.gameOver.Stop();
        am.carSound.Play();
	}
	void Update () 
    {
        if (currentPlatformisAndroid == true)
        {
            // Android Control / Input
            r = GetComponent<Rigidbody2D>();

            AndroidTouchMove(); 
        }
        else
        {
            // Windows Version
            carPosition.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            carPosition.x = Mathf.Clamp(carPosition.x, -limitBoundary, limitBoundary);
            transform.position = carPosition;
        }
        androidS();
	}
    void androidS()
    {
        carPosition = transform.position;
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
    // Android Control 
    
    public void MoveLeft()
    {
        r.velocity = new Vector2(-carSpeed-7, 0);
    }
    public void MoveRight()
    {
        r.velocity = new Vector2(carSpeed+7, 0);
    }
    public void SetVelocitytoZero()
    {
        r.velocity = Vector2.zero;
    }

    //Touch Event
    void AndroidTouchMove()
    {
        

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            float middlePos = Screen.width/2;
            if (t.position.x > middlePos && t.phase == TouchPhase.Began)
            {
                Debug.Log("Right");
                MoveRight();
            }
            else if (t.position.x < middlePos && t.phase == TouchPhase.Began)
            {
                Debug.Log("Left");
                MoveLeft();
            }
            else
            {
                SetVelocitytoZero();
            }
        }
    }
}
