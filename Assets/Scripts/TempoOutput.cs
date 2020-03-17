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
    private bool successfulPoint;
    private float leeway;
    private int beatCount;
    private int barCount;
    private int shapeCount;
    
    private float timer;
    private float beatIncrement;

    // Start is called before the first frame update
    void Start()
    {
        songTimer = Instantiate(songTimer);
        GetComponent<AudioSource>().Play();
        beatIncrement = 60 / tempo;
        timer = beatIncrement;
        bar = true;
        beat = true;
        leeway = 0.2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beat = false;
        bar = false;



        if (beatCount > 0)
        {
            Debug.Log(timer + " : " + songTimer.GetComponent<Timer>().counter);
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
            beatCount++;
            if (beatCount == 4)
            {
                bar = true;
                beatCount = 0;
                barCount++;
            }
        }
        
    }
}
