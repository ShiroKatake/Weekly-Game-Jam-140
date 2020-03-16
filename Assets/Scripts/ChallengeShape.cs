using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeShape : MonoBehaviour
{
    public float speed;
    public Sprite shape;
    public List<Sprite> shapeQueue;
    public bool reachedPlayer;
    private Vector3 targetScale;
    private Vector3 cutoffScale;
    private float initialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        cutoffScale = transform.localScale / 10;
        targetScale = transform.localScale / 50;
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
                speed = initialSpeed;
                //Reset the scale of the challenge shape. Change shape to the next one in the sequence.
                transform.localScale = new Vector3(1, 1);
                shape = shapeQueue[0];
            }
        }
    }
}
