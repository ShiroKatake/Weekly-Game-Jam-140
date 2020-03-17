using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Square,
    Circle,
    Triangle
}

public class Player : MonoBehaviour
{

    public GameObject cube;
    public GameObject sphere;
    public GameObject text;
    public float speed;
    private Vector3 minScale;
    private Vector3 maxScale;
    private Vector3 maxTargetScale;
    private State playerState;
    private bool rotate;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        minScale = transform.localScale / 20;
        maxScale = transform.localScale;
        maxTargetScale = transform.localScale * 1.3f;
        playerState = State.Circle;
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = score.ToString("00"); 
        rotate = false;
        if (Input.GetKey(KeyCode.W))
        {
            playerState = State.Triangle;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            playerState = State.Square;
        }
        else
        {
            playerState = State.Circle;
        }
        if (Input.GetKey(KeyCode.R))
        {
            rotate = true;
            score++;
        }

        if (rotate && transform.rotation.z <= 0.45)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 0.45f, 0), Time.deltaTime);
        }
        else if (transform.rotation.z > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 0, 0), Time.deltaTime);

        }
        if (playerState == State.Circle)
        {
            cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, minScale, speed * Time.deltaTime);
        }
        if (playerState == State.Square)
        {
            if (cube.transform.localScale.x < maxScale.x)
            {
                cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, maxTargetScale, speed * Time.deltaTime);

            }
        }
    }
}
