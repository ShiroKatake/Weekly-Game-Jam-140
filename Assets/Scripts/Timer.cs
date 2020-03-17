using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float counter;
    private float initial;


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
