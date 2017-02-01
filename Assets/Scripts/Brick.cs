using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
   
    public Sprite[] hitSprites;
    public static int blocksLeft = 0;

    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;
    // Use this for initialization
    void Start () {
        isBreakable = CompareTag("breakable");
        // Keep track of breakable blocks
        if (isBreakable)
        {
            blocksLeft++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (isBreakable)
        {
            HandleHits();
        }        
    }

    void HandleHits ()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            blocksLeft--;
            levelManager.BrickDestroyed();
            levelManager.PlayBrickSound(true);
            Destroy(gameObject);      
        }
        else
        {
            LoadSprites();
            levelManager.PlayBrickSound(false);
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }       
    }
    // TODO Remove this method once we can actually win
}
