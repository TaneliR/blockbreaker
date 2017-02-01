﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    private bool gameStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStarted)        
        {
            // Locked the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                // Stop holding ball when mouse is clicked.
                gameStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
            }
        }       
	}
}
