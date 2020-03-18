using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public RingManager ringManager;

    public Color pulseColor;
    public Color missedColor;
    public float speed;
    public bool reachedPlayer;
    public State shapeState;

    //Set of scales for transforming ring. target is used to lerp towards. Cutoff is shortly before that (as the lerp slows down
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 activeScale;
    private Vector3 inactiveScale;
    
    
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        targetScale = new Vector3(0,0,0);
        activeScale = transform.localScale / 12;
        inactiveScale = transform.localScale /15;

        StartCoroutine(ApproachPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedPlayer)
        {
            //Check if the ring has reached the cutoff size. Ring is Destroyed when it does.
            Debug.Log(transform.localScale.x + " : " + targetScale.x);
            if (transform.localScale.x <= targetScale.x)
            {
                Destroy(this.gameObject);
            }
            else if (transform.localScale.x < inactiveScale.x)
            {
                Debug.Log("Exit input window");
                ringManager.mainCamera.GetComponent<Camera>().backgroundColor = missedColor;
                active = false;
            }
            else if (transform.localScale.x < activeScale.x)
            {
                Debug.Log("Enter input window");
                if (active && ringManager.player.GetComponent<Player>().playerState == shapeState)
                {
                    Debug.Log("point awareded by: " + shapeState);
                    ringManager.mainCamera.GetComponent<Camera>().backgroundColor = pulseColor;
                    ringManager.goodSound.GetComponent<AudioSource>().Play();

                    ringManager.player.GetComponent<Player>().score++;
                    Destroy(this.gameObject);
                }
                else if (active && ringManager.player.GetComponent<Player>().playerState != State.None)
                {
                    Debug.Log("Missed!");
                    ringManager.mainCamera.GetComponent<Camera>().backgroundColor = missedColor;
                    ringManager.badSound.GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject);
                }
                active = true;
            }
            
        }
    }

    //This will move scale the ring down over time.
    private IEnumerator ApproachPlayer()
    {
        var timeStep = 0.0f;

        while(timeStep < 1.0f)
        {
            if (speed > 0.6)
            {
                speed -= 0.02f;
            }
            
            timeStep += Time.deltaTime * speed;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timeStep);

            yield return null;
        }
        
        
    }
}