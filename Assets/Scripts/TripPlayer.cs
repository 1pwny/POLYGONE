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
    private AudioSource sound;
    public AudioClip[] Effects;
    private Text text;
    private List<string> UpgradesPlayer1;
    private List<string> UpgradesPlayer2;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
        text = GameObject.Find("PowerUpDetail").GetComponent<Text>();
        transform.position = new Vector3(startingPos.x, startingPos.y, 0);
        sound = GetComponent<AudioSource>();
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
        if (gameObject.transform.position.y < -6f)
        {
            gameObject.transform.Translate(0f, 9f, 0f);
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector2(hSpeed, vSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Score--;
            ScoreText.text = Score.ToString();
        }*/
        if (collision.gameObject.tag.Equals("Star"))
        {
            sound.PlayOneShot(Effects[2], 0.5f);
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
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Score--;
            ScoreText.text = Score.ToString();
            StartCoroutine(WaittoDisable(0.25f, collision.gameObject.GetComponent<BoxCollider2D>()));
            sound.PlayOneShot(Effects[0], 0.5f);
        }
        if (collision.gameObject.tag.Equals("Bounds"))
        {
            sound.PlayOneShot(Effects[1], 0.5f);
        }
        if (collision.gameObject.tag.Equals("5") || collision.gameObject.tag.Equals("10") || collision.gameObject.tag.Equals("15"))
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (gameObject.tag.Equals("Player1"))
            {
                if (Score >= collision.gameObject.GetComponent<PowerUp>().Value)
                {
                    text.text = collision.gameObject.GetComponent<PowerUp>().Upgrade;
                    gameManager.AddPlayer1Up(text.text);
                    Score -= collision.gameObject.GetComponent<PowerUp>().Value;
                    Destroy(collision.gameObject);
                    ScoreText.text = Score.ToString();
                }

            }
            if (gameObject.tag.Equals("Player2"))
            {
                if (Score >= collision.gameObject.GetComponent<PowerUp>().Value)
                {
                    text.text = collision.gameObject.GetComponent<PowerUp>().Upgrade;
                    gameManager.AddPlayer2Up(text.text);
                    Score -= collision.gameObject.GetComponent<PowerUp>().Value;
                    Destroy(collision.gameObject);
                    ScoreText.text = Score.ToString();
                }
            }

        }
    }

    IEnumerator WaittoDisable(float t, Collider2D collider)
    {
        yield return new WaitForSeconds(t);
        collider.enabled = false;
    }
}
