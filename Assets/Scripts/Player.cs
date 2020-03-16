using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float speed;
    private Vector3 minScale;
    private Vector3 maxScale;
    private Vector3 maxTargetScale;
    private State playerState;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerState = State.Circle;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerState = State.Triangle;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerState = State.Square;
        }
        if (playerState == State.Circle)
        {
            cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, minScale, speed * Time.deltaTime);
        }
        if (playerState == State.Square)
        {
            if (cube.transform.localScale.x < maxScale.x)
            {
                Debug.Log("cubing");
                cube.transform.localScale = Vector3.Lerp(cube.transform.localScale, maxTargetScale, speed * Time.deltaTime);

            }
        }
    }
}
