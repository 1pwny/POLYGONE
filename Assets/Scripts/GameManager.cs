using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private enum GameType
    {
        ONLINE, LOCAL
    }
    private GameType gameType;

    private GameObject Player1;
    private GameObject Player2;
    private int Player1Money;
    private int Player2Money;
    public List<string> Player1Ups;
    public List<string> Player2Ups;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Preloading"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetGameType(int type)
    {
        if(type == 0)
        {
            gameType = GameType.LOCAL;
        }
        else
        {
            gameType = GameType.ONLINE;
        }
    }
    public void setPlayer1(GameObject obj)
    {
        Player1 = obj;
    }
    public void setPlayer2(GameObject obj)
    {
        Player2 = obj;
    }
    public GameObject getPlayer1()
    {
        return Player1;
    }
    public GameObject getPlayer2()
    {
        return Player2;
    }

    public void AddPlayer1Up(string up)
    {
        Player1Ups.Add(up);
        print(up);
    }
    public void AddPlayer2Up(string up)
    {
        Player2Ups.Add(up);
        print(up);
    }

    public void setPlayer1Money(int amount)
    {
        Player1Money = amount;
        print(Player1Money);
    }
    public void setPlayer2Money(int amount)
    {
        Player2Money = amount;
        print(Player2Money);
    }
    public int getPlayer1Money()
    {
        return Player1Money;
    }
    public int getPlayer2Money()
    {
        return Player2Money;
    }

    public bool isLocal()
    {
        return gameType == GameType.LOCAL;
    }
}
