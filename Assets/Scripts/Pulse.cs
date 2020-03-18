using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public GameObject mainCamera;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Debug.Log("Pulsing");
            mainCamera.GetComponent<Camera>().backgroundColor = Color.Lerp(mainCamera.GetComponent<Camera>().backgroundColor, Color.black, Mathf.PingPong(Time.time, 1));
        }
    }
}
