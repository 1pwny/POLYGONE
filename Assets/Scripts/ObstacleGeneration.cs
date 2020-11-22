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
    public GameObject[] PowerUps;
    public Transform[] PowerUpLocations;
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
        if (gameActive)
        {
            obj.transform.position = location;
            obj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
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
            var newStar = Instantiate(obj, location, Quaternion.identity);
            currCountStar++;
            newStar.transform.parent = Parent.transform;

        }
        if (gameActive)
        {
            currCountStar = 0;
            StartCoroutine(CreateStars(WaitPeriod, obj));
        }
    }
    public void MakePowerUps()
    {
        for(int i = 0; i< Parent.transform.childCount; i++)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
        for (int p = 0; p < PowerUpLocations.Length; p++)
        {
            var location = PowerUpLocations[p].position;
            var newObstacle = Instantiate(PowerUps[Random.Range(0, PowerUps.Length)], location, Quaternion.identity);
        }
        StartCoroutine(destroystuff(0.5f));
    }
    IEnumerator destroystuff(float f)
    {
        yield return new WaitForSeconds(f);
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
    }
}
