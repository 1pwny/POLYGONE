using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TripManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private GameManager gameManager;
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

}
