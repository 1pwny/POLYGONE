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
        Sprite newSprite = gameManager.getPlayer1().GetComponent<SpriteRenderer>().sprite;
        player1.GetComponent<SpriteRenderer>().sprite = newSprite;
        Sprite newSprite2 = gameManager.getPlayer2().GetComponent<SpriteRenderer>().sprite;
        player2.GetComponent<SpriteRenderer>().sprite = newSprite2;
    }

}
