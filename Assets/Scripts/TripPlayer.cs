using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TripPlayer : MonoBehaviour
{
    public bool isLocal;
    public Vector2 startingPos;
    public string hinput, vinput; //string for horizontal and vertical input
    private int Score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startingPos.x, startingPos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float hSpeed = 0.0f, vSpeed = 0.0f;

        if (isLocal)
        {
            
            hSpeed = Input.GetAxis(hinput) * 10;
            vSpeed = Input.GetAxis(vinput) * 10;
            
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector2(hSpeed, vSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Score--;
            ScoreText.text = Score.ToString();
        }
        if (collision.gameObject.tag.Equals("Star"))
        {
            Score++;
            ScoreText.text = Score.ToString();
            Destroy(collision.gameObject);
        }
    }
    public int getScore()
    {
        return Score;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided with " + collision.gameObject);
    }
}
