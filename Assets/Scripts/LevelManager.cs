using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public AudioClip[] audioClips;
    private new AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void LoadLevel(string name)


    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }
    public void QuitRequest(string name)
    {
        Debug.Log("Trying to Quit the game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayBrickSound(bool breaks)
    {
        if (breaks)
        {
            audio.clip = audioClips[3];
            audio.Play();
        }
        else
        {
            audio.clip = audioClips[Random.Range(0, 2)];
            audio.Play();
        }          
    }
    public void BrickDestroyed()
    {
        if (Brick.blocksLeft <= 0)
        {
            LoadNextLevel(); 
        }
    }
}
