using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeShape : MonoBehaviour
{    public GameObject musicManager;
    public Sprite square;
    public Sprite circle;
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
            Object.Instantiate(new Shape(shapeQueue[shapeCount]));
            shapeCount += 1;
        }
    }
}
