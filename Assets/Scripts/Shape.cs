using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool reachedPlayer;
    public State shapeState;
    private Vector3 targetScale;
    private Vector3 cutoffScale;
    private Vector3 activeScale;
    private Vector3 inactiveScale;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.name);
        if (this.name == "Circle(Clone)")
        {
            shapeState = State.Circle;
        }
        else if (this.name == "Triangle(Clone)")
        {
            shapeState = State.Triangle;
        }
        else
        {
            shapeState = State.Square;
        }
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