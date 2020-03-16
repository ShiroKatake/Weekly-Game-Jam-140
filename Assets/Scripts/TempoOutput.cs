using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoOutput : MonoBehaviour
{
    public float tempo;
    public bool beat;
    public bool bar;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beat = false;
        bar = false;
        if (timer <= Time.time)
        {
            beat = true;
            beatCount++;
            timer += beatIncrement;
            transform.GetComponent<AudioSource>().Play();
            if (beatCount == 4)
            {
                bar = true;
                beatCount = 0;
            }
        }
        
    }
}
