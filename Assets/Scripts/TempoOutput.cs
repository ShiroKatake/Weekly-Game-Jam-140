using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoOutput : MonoBehaviour
{
    public float tempo;
    public bool beat;
    private float timer;
    private float beatIncrement;

    // Start is called before the first frame update
    void Start()
    {
        beatIncrement = 60 / tempo;
        timer = beatIncrement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        beat = false;
        if (timer <= Time.time)
        {
            beat = true;
            timer += beatIncrement;
            transform.GetComponent<AudioSource>().Play();
        }
        
    }
}
