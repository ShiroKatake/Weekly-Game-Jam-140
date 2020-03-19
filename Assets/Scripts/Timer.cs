using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float counter;
    private float initial;

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
        counter = Time.time - initial;
    }
}
