using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject Star;
    public GameObject Parent;
    public int currCountObs;
    public int CountObs;
    public int currCountStar;
    public int CountStar;
    public float radius;
    public float WaitPeriod;
    public bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateOnInterval(WaitPeriod));
        StartCoroutine(CreateStars(WaitPeriod, Star));
    }

    IEnumerator GenerateOnInterval(float f)
    {
        yield return new WaitForSeconds(f);
        while (currCountObs < CountObs)
        {
            currCountObs++;
            var location = new Vector2((Random.value - 0.5f) * radius, ((Random.value - 0.5f) * radius+10f));
            var newObstacle = Instantiate(Obstacle, location, Quaternion.identity);
            newObstacle.name = "o" + currCountObs.ToString();
            newObstacle.transform.parent = Parent.transform;
            StartCoroutine(MoveObject(WaitPeriod, newObstacle));
        }
        currCountObs = 0;

    }
    IEnumerator MoveObject(float f, GameObject obj)
    {
        yield return new WaitForSeconds(f);
        var location = new Vector2((Random.value - 0.5f) * radius, ((Random.value - 0.5f) * radius + 10f));
        obj.transform.position = location;
        if (gameActive)
        {
            StartCoroutine(MoveObject(WaitPeriod, obj));
        }
    }
    IEnumerator CreateStars(float f, GameObject obj)
    {
        yield return new WaitForSeconds(f);
        MakeStars(WaitPeriod, obj);
    }
    private void MakeStars(float f, GameObject obj)
    {
        while (currCountStar < CountStar)
        {
            var location = new Vector2((Random.value - 0.5f) * radius, ((Random.value - 0.5f) * radius + 10f));
            var newObstacle = Instantiate(obj, location, Quaternion.identity);
            currCountStar++;
        }
        if (gameActive)
        {
            currCountStar = 0;
            StartCoroutine(CreateStars(WaitPeriod, obj));
        }
    }
}
