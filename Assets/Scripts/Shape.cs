using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float speed;
    public bool reachedPlayer;
    private Vector3 targetScale;
    private Vector3 cutoffScale;
    private float initialSpeed;

    public Shape(Sprite shape)
    {
        transform.GetComponent<SpriteRenderer>().sprite = shape;
    }

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
                GameObject.Destroy(this);
            }
        }
    }
}
