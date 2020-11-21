using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripBoundaries : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.color.a <= 0.01f)
        {
            sr.color = new Color(255, 255, 255, 0);
        }
        else if (sr.color.a > 0)
        {
            sr.color = new Color(255, 255, 255, sr.color.a - 0.01f);
            //print("Changed");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("nothing");

        if(collision.gameObject.tag.Equals("Player"))
        { 
            //if (sr.color.a > 0)
                //return;

            sr.color = new Color(255, 255, 255, 0.5f);
        }
    }
}
