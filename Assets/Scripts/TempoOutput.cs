using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoOutput : MonoBehaviour
{
    public GameObject shape;
    public Song song;
    public Text uITimer;
    public int beatOffest;

    private int beatsInBar;
    private int beatCount;

    private bool beat;
    private bool bar;
    private float timer;
    private bool paused;

    public bool Paused
    {
        get
        {
            return paused;
        }
    }

    public bool Beat
    {
        get
        {
            return beat;
        }
    }

    public bool Bar
    {
        get
        {
            return bar;
        }
    }

    public string BeatsRemaining
    {
        get
        {
            int beats = song.totalBeats - beatCount + beatOffest;
            if (beats < 0)
            {
                beats = 0;
            }
            return (beats.ToString("00"));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = song.BeatIncrement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beat = false;
        bar = false;

        uITimer.text = BeatsRemaining;
        
        if (song.Time > 0 && timer <= song.Time)
        {
            timer += song.BeatIncrement;
            beat = true;
            beatsInBar++;
            beatCount++;
            if (beatsInBar == 4)
            {
                bar = true;
                beatsInBar = 0;
            }
        }
    }

    public void Pause()
    {
        song.Pause();
        paused = true;
    }

    public void Play()
    {
        song.Play();
        paused = false;
    }
}
