using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public GameObject badSound;
    public GameObject goodSound;
    public Color pulseColor;
    public Color missedColor;
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
        activeScale = transform.localScale / 30;
        inactiveScale = transform.localScale / 32;
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
                mainCamera.GetComponent<Camera>().backgroundColor = missedColor;
                active = false;
            }
            else if (transform.localScale.x < activeScale.x)
            {
                if (active && player.GetComponent<Player>().playerState == shapeState)
                {
                    Debug.Log("point awareded by: " + shapeState);
                    mainCamera.GetComponent<Camera>().backgroundColor = pulseColor;
                    goodSound.GetComponent<AudioSource>().Play();

                    player.GetComponent<Player>().score++;
                    Destroy(this.gameObject);
                }
                else if (active && player.GetComponent<Player>().playerState != State.None)
                {
                    Debug.Log("Missed!");
                    mainCamera.GetComponent<Camera>().backgroundColor = missedColor;
                    badSound.GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject);
                }
                active = true;
            }
            
        }
    }
}