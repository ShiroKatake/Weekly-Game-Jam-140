using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeShape : MonoBehaviour
{    public GameObject musicManager;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    public List<Sprite> shapeQueue;
    private int shapeCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (musicManager.GetComponent<TempoOutput>().beat)
        {
            Instantiate(square);
            shapeCount += 1;
        }
    }
}
