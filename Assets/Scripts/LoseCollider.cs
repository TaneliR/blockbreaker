using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    
    void OnTriggerEnter2D (Collider2D trigger)
    {
        SceneManager.LoadScene("Lose Screen");      
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        print("Collision");
    }
}
