using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private bool gameStarted = false;
    private Paddle paddle;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!gameStarted)        
        {
            // Locked the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                // Stop holding ball when mouse is clicked.
                gameStarted = true;
                rigidBody.velocity = new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(10f, 12f));
            }
        }       
	}
    void OnCollisionEnter2D (Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 3f));
        rigidBody.velocity += tweak;
    }
}
