using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RingManager : MonoBehaviour
{
    public GameObject fader;
    public GameObject uIScore;
    public GameObject uITimer;
    public GameObject badSound;
    public GameObject goodSound;
    public Color black;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject musicManager;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;
    private GameObject shape;
    public string shapesString;
    public List<State> shapeQueue;
    public Color tempColor;
    private int shapeCount;
    private bool isCoroutineExecuting = false;
    private bool isFadeOutExecuting = false;
    private bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        string[] shapelist = shapesString.Split('-');
        shapeQueue = new List<State>();
        foreach (string shape in shapelist)
        {
            if (shape == "q")
            {
                shapeQueue.Add(State.Circle);
            }
            else if (shape == "w")
            {
                shapeQueue.Add(State.Triangle);
            }
            else if (shape == "e")
            {
                shapeQueue.Add(State.Square);
            }
            else
            {
                shapeQueue.Add(State.None);
            }
        }        
        tempColor = fader.GetComponent<Material>().color;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (musicManager.GetComponent<TempoOutput>().beat)
        {
            uITimer.GetComponent<Text>().text = (musicManager.GetComponent<TempoOutput>().BeatsRemaining);
            try
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
                shape.GetComponent<Ring>().ringManager = this;
                shapeCount += 1;
            }
            catch
            {
                StartCoroutine(FadeOut(3));
                if (fadeOut)
                {
                    uIScore.GetComponent<Text>().color = Color.Lerp(uIScore.GetComponent<Text>().color, black, Mathf.PingPong(Time.time / 2, 1));
                    uIScore.GetComponent<Text>().color = Color.Lerp(uIScore.GetComponent<Text>().color, black, Mathf.PingPong(Time.time / 2, 1));
                    tempColor.a = Mathf.MoveTowards(0, 1, Time.deltaTime);
                    fader.GetComponent<Material>().color = tempColor;
                }
                StartCoroutine(SongEnd(6));
            }
            
        }
    }

    IEnumerator FadeOut(float time)
    {
        if (isFadeOutExecuting)
            yield break;

        isFadeOutExecuting = true;

        yield return new WaitForSeconds(time);

        fadeOut = true;

        isFadeOutExecuting = false;
    }

    IEnumerator SongEnd(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(2);

        isCoroutineExecuting = false;
    }
}
