using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public AudioSource song;
    public float tempo;
    public int totalBeats;
    public string shapeString;

    public Timer songTimer;

    private float beatIncrement;
    public List<State> shapeQueue = new List<State>();
    private int i = -1;

    // Return the next shape in the queue
    public State NextShape
    {
        get
        {
            i++;
            return shapeQueue[i];
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

    // Start is called before the first frame update
    void Start()
    {
        beatIncrement = 60 / tempo;
        songTimer = Instantiate(songTimer);

        // Take the input string and convert it into a list of states
        string[] shapelist = shapeString.Split('-');
        
        foreach (string shape in shapelist)
        {
            if (shape == "q")
            {
                shapeQueue.Add(State.Circle);
            }
            else if (shape == "w")
            {
                shapeQueue.Add(State.Triangle);
            }
            else if (shape == "e")
            {
                shapeQueue.Add(State.Square);
            }
            else
            {
                shapeQueue.Add(State.None);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
