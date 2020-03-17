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
            mainCamera.GetComponent<Camera>().backgroundColor = Color.Lerp(Color.gray, Color.black, 8*Time.deltaTime);
        }
    }
}
