using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public TempoOutput tempoOutput;
    public Canvas menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoOutput.Paused)
        {
            transform.localPosition = new Vector3(0,0,-1);
            menu.enabled = true;
        }
        else
        {
            transform.localPosition= new Vector3(0, 100, -1);
            menu.enabled = false;
        }
    }
}
