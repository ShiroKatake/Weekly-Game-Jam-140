using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeShape : MonoBehaviour
{
    public GameObject fader;
    public Color transparent, black;
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
    private bool isCoroutineExecuting = false;
    private bool isFadeOutExecuting = false;

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
                shape.GetComponent<Shape>().player = Player;
                shape.GetComponent<Shape>().mainCamera = mainCamera;
                shapeCount += 1;
            }
            catch
            {
                StartCoroutine(FadeOut(3));
                StartCoroutine(SongEnd(6));
            }
            
        }
    }

    IEnumerator FadeOut(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isFadeOutExecuting = true;

        yield return new WaitForSeconds(time);

        fader.GetComponent<Material>().color = Color.Lerp(transparent, black, 1);
        

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
