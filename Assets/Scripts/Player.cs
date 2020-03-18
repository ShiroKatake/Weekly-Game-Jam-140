using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Square,
    Circle,
    Triangle,
    None
}

public class Player : MonoBehaviour
{

    public GameObject cube;
    public GameObject cylinder;
    public GameObject triangle;
    public GameObject text;
    public float speed;
    public State playerState;
    public int score;

    private Vector3 minScale;
    private Vector3 maxScale;
    private Vector3 maxTriangleScale;
    private Vector3 maxTargetScale;
    private bool rotate;
    

    // Start is called before the first frame update
    void Start()
    {
        minScale = transform.localScale / 20;
        maxScale = transform.localScale;
        maxTriangleScale = new Vector3(126.9933f, 11.9905f, 138.2243f);
        maxTargetScale = transform.localScale * 1.3f;
        playerState = State.Circle;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Score", score);
        text.GetComponent<Text>().text = score.ToString("00"); 
        rotate = false;

        if (Input.GetKey(KeyCode.E))
        {
            playerState = State.Square;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerState = State.Triangle;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            playerState = State.Circle;
        }
        
        else
        {
            playerState = State.None;
        }
        if (Input.GetKey(KeyCode.R))
        {
            rotate = true;
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
            if (cylinder.transform.localScale.x < maxScale.x)
            {
                cylinder.transform.localScale = Vector3.Lerp(cylinder.transform.localScale, maxTargetScale, speed * Time.deltaTime);
            }
        }
        else
        {
            cylinder.transform.localScale = Vector3.Lerp(cylinder.transform.localScale, minScale, speed * Time.deltaTime);
        }
        if (playerState == State.Square)
        {
            if (cube.transform.localScale.x < maxScale.x)
            {
                cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, maxTargetScale, speed * Time.deltaTime);
            }
        }
        else
        {
            cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, minScale, speed * Time.deltaTime);
        }
        if (playerState == State.Triangle)
        {
            triangle.transform.localScale = Vector3.Lerp(triangle.transform.localScale, maxTriangleScale, speed * Time.deltaTime);
        }
        else
        {
            triangle.transform.localScale = Vector3.Lerp(triangle.transform.localScale, maxTriangleScale/50, speed * Time.deltaTime);
        }
    }
}
