using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoOutput : MonoBehaviour
{
    public GameObject shape;
    public float tempo;
    public bool beat;
    public bool bar;
    public bool inputWindow;
    public GameObject songTimer;
    private float leeway;
    private int totalBeats;
    private int beatsInBar;
    private int beatCount;
    
    private float timer;
    public float beatIncrement;

    // Start is called before the first frame update
    void Start()
    {
        songTimer = Instantiate(songTimer);
        totalBeats = 48;
        GetComponent<AudioSource>().Play();
        beatIncrement = 60 / tempo;
        timer = beatIncrement;
        bar = true;
        beat = true;
        leeway = 0.2f;
    }

    public string BeatsRemaining
    {
        get
        {
            return (totalBeats - beatCount).ToString("00");
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        beat = false;
        bar = false;

        

        if (beatsInBar > 0)
        {
            if (timer <= songTimer.GetComponent<Timer>().counter + leeway || (timer - (beatIncrement - leeway)) >= songTimer.GetComponent<Timer>().counter)
            {
                inputWindow = true;
            }
            else
            {
                inputWindow = false;

            }
        }
        if (timer <= songTimer.GetComponent<Timer>().counter)
        {
            timer += beatIncrement;
            beat = true;
            beatsInBar++;
            if (beatCount == 4)
            {
                bar = true;
                beatsInBar = 0;
            }
        }
        
    }
}
