using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RingManager : MonoBehaviour
{
    public GameObject fader;
    public GameObject uIScore;
    public GameObject uITimer;
    public GameObject badSound;
    public GameObject goodSound;
    public GameObject player;
    public GameObject mainCamera;

    public TempoOutput tempoOutput;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    public Song song;

    private GameObject ring;
    private bool isCoroutineExecuting = false;
    //private bool isFadeOutExecuting = false;
    //private bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tempoOutput.Beat)
        {
            uITimer.GetComponent<Text>().text = (tempoOutput.BeatsRemaining);
            try
            {
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
                StartCoroutine(SongEnd(6));
            }
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

        SceneManager.LoadScene(1);

        isCoroutineExecuting = false;
    }
}
