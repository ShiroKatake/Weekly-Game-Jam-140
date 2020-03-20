using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Song : MonoBehaviour
{
    public AudioSource song;
    public float tempo;
    public int totalBeats;
    public string ringString;
    public float individualSongOffset;
    public List<State> ringQueue = new List<State>();


    public Timer songTimer;

    private float songStartOffset;
    private float beatIncrement;
    private int i = -1;

    // Return the next shape in the queue
    public State NextShape
    {
        get
        {
            i++;
            return ringQueue[i];
        }
    }

    public float BeatIncrement
    {
        get
        {
            return beatIncrement;
        }
    }

    public float Time
    {
        get
        {
            return songTimer.Counter;
        }
    }

    public void StartSong()
    {
        StartCoroutine(DelaySong());
    }

    private IEnumerator DelaySong()
    {
        yield return new WaitForSeconds(songStartOffset);
        song.Play();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        beatIncrement = 60 / tempo;
        songStartOffset = beatIncrement*individualSongOffset;
        songTimer = Instantiate(songTimer);
        StartSong();
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        

        // Take the input string and convert it into a list of states
        string[] shapelist = ringString.Split('-');
        
        foreach (string shape in shapelist)
        {
            if (shape == "q")
            {
                ringQueue.Add(State.Circle);
            }
            else if (shape == "w")
            {
                ringQueue.Add(State.Triangle);
            }
            else if (shape == "e")
            {
                ringQueue.Add(State.Square);
            }
            else
            {
                ringQueue.Add(State.None);
            }

            totalBeats = ringQueue.Count;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        song.Pause();
        songTimer.Pause();
    }

    public void Play()
    {
        song.Play();
        songTimer.Play();
    }
}
