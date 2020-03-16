using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoOutput : MonoBehaviour
{
    public float tempo;
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
        if (timer <= Time.time)
        {
            Debug.Log("beat: " + Time.time + " : " + timer);
            timer += beatIncrement;
            transform.GetComponent<AudioSource>().Play();
        }
        
    }
}
