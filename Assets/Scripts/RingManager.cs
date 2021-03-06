﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RingManager : MonoBehaviour
{
    public AudioSource badSound;
    public AudioSource goodSound;
    public Player player;
    public Camera mainCamera;
    public Song song;
    public TempoOutput tempoOutput;

    // Ring Prefabs
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    

    private GameObject ring;
    private bool isCoroutineExecuting = false;

    public bool Paused
    {
        get
        {
            return tempoOutput.Paused;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(tempoOutput.Beat + " : " + tempoOutput.Paused);
        if (tempoOutput.Beat && !tempoOutput.Paused)
        {
            try
            {
                // Create next ring in queue
                switch (song.NextShape)
                {
                    case State.Circle:
                        ring = Instantiate(circle);
                        break;
                    case State.Triangle:
                        ring = Instantiate(triangle);
                        break;
                    case State.Square:
                        ring = Instantiate(square);
                        break;
                    case State.None:
                        break;
                }
            }
            catch
            {
                // End song when nullReference is thrown (when there are no more shapes in the queue
                StartCoroutine(SongEnd(6));
            }

            // When ring isn't null (when there is a rest in the queue)
            try
            {
                ring.GetComponent<Ring>().ringManager = this;
            }
            catch
            {

            }
        }
    }

    IEnumerator SongEnd(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(2);

        isCoroutineExecuting = false;
    }
}
