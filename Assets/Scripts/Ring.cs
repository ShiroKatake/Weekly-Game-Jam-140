using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public RingManager ringManager;

    public Color pulseColor;
    public Color missedColor;
    private float speed = 2.05f;
    public bool reachedPlayer;
    public State shapeState;

    // Set of scales for transforming ring. target is used to lerp towards. Cutoff is shortly before that (as the lerp slows down
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 activeScale;
    private Vector3 inactiveScale;

    private float timeStep = 0.0f;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        targetScale = new Vector3(0,0,0);
        activeScale = transform.localScale / 24;
        inactiveScale = transform.localScale /40;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ringManager.Paused)
        {
            ApproachPlayer();
        }
        
        // Check if the ring has reached the cutoff size. Ring is Destroyed when it does.
        if (transform.localScale.x <= targetScale.x)
        {
            Destroy(this.gameObject);
        }
        // Check if the ring has passed the input window
        else if (transform.localScale.x < inactiveScale.x)
        {
            //ringManager.mainCamera.backgroundColor = missedColor;
            active = false;
        }
        // Check if the ring has entered the input window
        else if (transform.localScale.x < activeScale.x)
        {

            // Player is in the right state when the ring reaches them
            if (active && ringManager.player.playerState == shapeState)
            {
                ringManager.mainCamera.backgroundColor = pulseColor;
                ringManager.goodSound.Play();

                ringManager.player.GetComponent<Player>().score++;
                Destroy(this.gameObject);
            }

            // Player is in the wrong state (excluding none state) when the ring reaches them
            else if (active && ringManager.player.playerState != State.None)
            {
                ringManager.mainCamera.backgroundColor = missedColor;
                ringManager.badSound.Play();
                Destroy(this.gameObject);
            }

            active = true;
        }
    }

    // Scale the ring down over time.
    private void ApproachPlayer()
    {
        if (timeStep < 1.0f)
        {
            if (speed > 0.6)
            {
                speed -= 0.02f;
            }

            timeStep += Time.deltaTime * speed;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timeStep);
        }
    }
}