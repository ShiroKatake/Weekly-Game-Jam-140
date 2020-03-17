using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoOutput : MonoBehaviour
{
    public float tempo;
    public bool beat;
    public bool bar;
    public bool inputWindow;
    private float leeway;
    private int beatCount;
    private float timer;
    private float beatIncrement;

    // Start is called before the first frame update
    void Start()
    {
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
        if (timer <= Time.time + leeway ||  (timer - (beatIncrement - leeway)) >= Time.time)
        {
            inputWindow = true;
        }
        else
        {
            inputWindow = false;
            
        }
        if (timer <= Time.time)
        {
            timer += beatIncrement;
            beat = true;
            beatCount++;
            transform.GetComponent<AudioSource>().Play();
            if (beatCount == 4)
            {
                bar = true;
                beatCount = 0;
            }
        }
        
    }
}
