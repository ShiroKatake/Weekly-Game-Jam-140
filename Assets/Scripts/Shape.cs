using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public Color pulseColor;
    public float speed;
    public bool reachedPlayer;
    public State shapeState;
    private Vector3 targetScale;
    private Vector3 cutoffScale;
    private Vector3 activeScale;
    private Vector3 inactiveScale;
    private bool active;
    private bool pulse;

    // Start is called before the first frame update
    void Start()
    {
        cutoffScale = transform.localScale / 40;
        targetScale = transform.localScale / 50;
        activeScale = transform.localScale / 28;
        inactiveScale = transform.localScale / 34;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedPlayer)
        {

            speed += 0.005f;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
            if (transform.localScale.x < cutoffScale.x)
            {
                Destroy(this.gameObject);
            }
            else if (transform.localScale.x < inactiveScale.x)
            {
                active = false;
            }
            else if (transform.localScale.x < activeScale.x)
            {
                if (!pulse)
                {
                    mainCamera.GetComponent<Camera>().backgroundColor = pulseColor;
                    pulse = true;
                }
                if (active && player.GetComponent<Player>().playerState == shapeState)
                {
                    Debug.Log("point awareded by: " + shapeState);
                    

                    player.GetComponent<Player>().score++;
                    Destroy(this.gameObject);
                }
                else if (active && player.GetComponent<Player>().playerState != State.None)
                {
                    Debug.Log("Missed!");
                    Destroy(this.gameObject);
                }
                active = true;
            }
            
        }
    }
}