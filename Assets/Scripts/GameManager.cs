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


}
