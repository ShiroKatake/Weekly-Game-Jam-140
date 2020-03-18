using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Camera>().backgroundColor = Color.Lerp(GetComponent<Camera>().backgroundColor, Color.black, Mathf.Lerp(0, 1, 20*Time.deltaTime));
    }
}
