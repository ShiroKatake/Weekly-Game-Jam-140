using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeShape : MonoBehaviour
{    public GameObject musicManager;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    public List<int> shapeQueue;
    private int shapeCount;

    // Start is called before the first frame update
    void Start()
    {
        shapeQueue = new List<int> { 0, 1, 2, 2, 1, 1, 2 };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (musicManager.GetComponent<TempoOutput>().bar)
        {
            switch (shapeQueue[shapeCount])
            {
                case 0:
                    Instantiate(circle);
                    break;
                case 1:
                    Instantiate(triangle);
                    break;
                case 2:
                    Instantiate(square);
                    break;
            }
            shapeCount += 1;
        }
    }
}
