using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeShape : MonoBehaviour
{
    public GameObject Player;
    public GameObject mainCamera;
    public GameObject totalShapes;
    public GameObject musicManager;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    private GameObject shape;
    public List<State> shapeQueue;
    private int shapeCount;

    // Start is called before the first frame update
    void Start()
    {
        shapeQueue = new List<State> { State.Circle, State.Triangle, State.Square, State.Square, State.Triangle, State.Triangle, State.Square, State.Circle, State.Triangle, State.Square, State.Square, State.Triangle, State.Triangle, State.Square, State.Circle, State.Triangle, State.Square, State.Square, State.Triangle, State.Triangle, State.Square, State.Circle, State.Triangle, State.Square, State.Square, State.Triangle, State.Triangle, State.Square };
        totalShapes.GetComponent<Text>().text = shapeQueue.Count.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (musicManager.GetComponent<TempoOutput>().beat)
        {
            switch (shapeQueue[shapeCount])
            {
                case State.Circle:
                    shape = Instantiate(circle);
                    break;
                case State.Triangle:
                    shape = Instantiate(triangle);
                    break;
                case State.Square:
                    shape = Instantiate(square);
                    break;
            }
            shape.GetComponent<Shape>().player = Player;
            shape.GetComponent<Shape>().mainCamera = mainCamera;
            shapeCount += 1;
        }
    }
}
