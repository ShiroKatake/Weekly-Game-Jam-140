using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float counter;
    private float initial;
    private bool paused;
    private float pause;

    public float Counter
    {
        get
        {
            return counter;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initial = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            counter = Time.time - initial - pause;
        }
        else
        {
            pause += Time.deltaTime;
        }
    }

    public void Pause()
    {
        paused = true;
    }

    public void Play()
    {
        paused = false;
    }
}
