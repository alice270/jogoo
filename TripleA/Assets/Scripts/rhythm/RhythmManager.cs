using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource theMusic;

    public BeatScroller theBS;
    public BeatScrollerHorizontal theBSH;
    public bool startPlaying;
    public static RhythmManager instance;
    public Text Life;

    public int health = 3 ;
    public event Action<bool> terminarBatalha;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theBSH.hasStarted = true;

                theMusic.Play();
            }
        }
        if (health <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            terminarBatalha(true);
        }

    }

    public void NoteHit()
    {
        Debug.Log("Hit");

    }

    public void NoteMissed()
    {
        Debug.Log("Miss");
        health--;
        Life.text = "Life:" + health;

    }

    void Die()
    {
        Destroy(player);
    }
}
