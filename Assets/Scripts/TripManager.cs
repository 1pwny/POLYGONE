using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TripManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Text Timer;
    public float time = 60;
    public ObstacleGeneration ObsGen;
    public GameObject ContinueButton;
    private GameManager gameManager;
    private Color baseColor = Color.black;
    private Color hoverColor = Color.red;
    public GameObject middleBoundary;
    public GameObject rightBoundary;
    public GameObject leftBoundary;
    public GameObject centerBoundary;
    public ScrollingBG[] backgrounds;
    public bool endedGame = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.isLocal())
        { 
            localSetup();
        }
        else
        {
            onlineSetup();
        }
        Timer.text = time.ToString();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time > 0f)
        {
            string timeString = string.Format("{0:N0}", time);
            Timer.text = timeString;
        }
        else
        {
            if (!endedGame)
            {
                ObsGen.gameActive = false;
                Timer.text = "Shop";
                gameManager.setPlayer1Money(player1.GetComponent<TripPlayer>().getScore());
                gameManager.setPlayer2Money(player2.GetComponent<TripPlayer>().getScore());
                ContinueButton.SetActive(true);
                middleBoundary.gameObject.transform.Translate(4.7f, 0f, 0f);
                leftBoundary.transform.localScale += new Vector3(0f, 11f, 0f);
                rightBoundary.transform.localScale += new Vector3(0f, 11f, 0f);
                centerBoundary.transform.localScale += new Vector3(0f, 11f, 0f);
                backgrounds[0].gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                backgrounds[1].gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                ObsGen.MakePowerUps();
                endedGame = true;
            }
            
        }
        
    }

    public void ButtonHover(Text button)
    {
        button.color = hoverColor;
    }

    public void ButtonHoverExit(Text button)
    {
        button.color = baseColor;
    }

    void localSetup()
    {
        Sprite newSprite = gameManager.getPlayer1().GetComponent<SpriteRenderer>().sprite;
        player1.GetComponent<SpriteRenderer>().sprite = newSprite;
        Sprite newSprite2 = gameManager.getPlayer2().GetComponent<SpriteRenderer>().sprite;
        player2.GetComponent<SpriteRenderer>().sprite = newSprite2;

        player1.GetComponent<TripPlayer>().isLocal = true;
        player1.GetComponent<TripPlayer>().hinput = "Horizontal";
        player1.GetComponent<TripPlayer>().vinput = "Vertical";

        player2.GetComponent<TripPlayer>().isLocal = true;
        player2.GetComponent<TripPlayer>().hinput = "Horizontal 2";
        player2.GetComponent<TripPlayer>().vinput = "Vertical 2";
    }

    void onlineSetup()
    {
        Debug.Log("nothing here lmao");
        localSetup();
    }

    public void ContinueToArena()
    {
        SceneManager.LoadScene("Arena");
    }

}
