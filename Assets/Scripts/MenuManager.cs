using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject StartButtons;
    public GameObject OptionButtons;
    public GameObject GameStartButtons;
    private GameManager gameManager;
    public Animator camAnim;
    public GameObject CharacterSelectButtons;
    public Image[] CharacterButtons;
    public GameObject[] colorCharacters;
    private bool Player1Selected = false;
    private Image player1SelectedImage;
    private bool Player2Selected = false;
    private Image player2SelectedImage;
    private enum Colors
    {
        blue, red, purple, black
    }
    private Colors player1Color;
    private Colors player2Color;

    private Color baseColor = Color.black;
    private Color hoverColor = Color.red;

    private AudioSource ClickSound;


    private void Start()
    {
        ClickSound = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player1Color = Colors.black;
        player2Color = Colors.black;
    }

    #region Buttons

    public void ButtonHover(Text button)
    {
        button.color = hoverColor;
    }

    public void ButtonHoverExit(Text button)
    {
        button.color = baseColor;
    }

    public void OpenOptions(Text button)
    {
        StartButtons.SetActive(false);
        OptionButtons.SetActive(true);
        button.color = baseColor;
        ClickSound.Play();
    }
    public void LeaveOptions(Text button)
    {
        OptionButtons.SetActive(false);
        StartButtons.SetActive(true);
        button.color = baseColor;
        ClickSound.Play();
    }
    public void StartButton(Text button)
    {
        StartButtons.SetActive(false);
        GameStartButtons.SetActive(true);
        button.color = baseColor;
        ClickSound.Play();
    }
    public void LeaveGameOptions(Text button)
    {
        GameStartButtons.SetActive(false);
        StartButtons.SetActive(true);
        button.color = baseColor;
        ClickSound.Play();
    }

    public void StartOnline(Text button)
    {
        GameStartButtons.SetActive(false);
        CharacterSelectButtons.SetActive(true);
        gameManager.SetGameType(1);
        button.color = baseColor;
        ClickSound.Play();
        camAnim.SetTrigger("backgroundslide");
    }
    public void StartLocal(Text button)
    {
        GameStartButtons.SetActive(false);
        CharacterSelectButtons.SetActive(true);
        gameManager.SetGameType(0);
        button.color = baseColor;
        ClickSound.Play();
        camAnim.SetTrigger("backgroundslide");
    }
    public void LeaveCharacterSelect(Text button)
    {
        button.color = baseColor;
        ClickSound.Play();
        camAnim.SetTrigger("reverseslide");
        GameStartButtons.SetActive(true);
        CharacterSelectButtons.SetActive(false);
    }
    
    public void setPlayer1(GameObject shape)
    {
        ClickSound.Play();
        gameManager.setPlayer1(shape);
        print("set player 1 as " + shape.name);
        if (Player1Selected)
        {
            player1SelectedImage.color = Color.clear;
            Player1Selected = false;
        }
        if (shape.name.StartsWith("Triangle"))
        {
            CharacterButtons[1].color = Color.red;
            Player1Selected = true;
            player1SelectedImage = CharacterButtons[1];
        }
        if (shape.name.StartsWith("Square"))
        {
            CharacterButtons[2].color = Color.red;
            Player1Selected = true;
            player1SelectedImage = CharacterButtons[2];
        }
        if (shape.name.StartsWith("Circle"))
        {
            CharacterButtons[0].color = Color.red;
            Player1Selected = true;
            player1SelectedImage = CharacterButtons[0];
        }

    }
    public void setPlayer2(GameObject shape)
    {
        ClickSound.Play();
        gameManager.setPlayer2(shape);
        print("set player 2 as " + shape.name);
        if (Player2Selected)
        {
            player2SelectedImage.color = Color.clear;
            Player2Selected = false;
        }
        if (shape.name.StartsWith("Triangle"))
        {
            CharacterButtons[4].color = Color.red;
            Player2Selected = true;
            player2SelectedImage = CharacterButtons[4];
        }
        if (shape.name.StartsWith("Square"))
        {
            CharacterButtons[5].color = Color.red;
            Player2Selected = true;
            player2SelectedImage = CharacterButtons[5];
        }
        if (shape.name.StartsWith("Circle"))
        {
            CharacterButtons[3].color = Color.red;
            Player2Selected = true;
            player2SelectedImage = CharacterButtons[3];
        }
    }
    public void GoToTripScene(Text button)
    {
        if(Player1Selected && Player2Selected)
        {
            if(player1Color == Colors.blue)
            {
                if(player1SelectedImage == CharacterButtons[0])
                {
                    gameManager.setPlayer1(colorCharacters[0]);
                }
                if (player1SelectedImage == CharacterButtons[1])
                {
                    gameManager.setPlayer1(colorCharacters[6]);
                }
                if (player1SelectedImage == CharacterButtons[2])
                {
                    gameManager.setPlayer1(colorCharacters[3]);
                }
            }
            if (player1Color == Colors.purple)
            {
                if (player1SelectedImage == CharacterButtons[0])
                {
                    gameManager.setPlayer1(colorCharacters[1]);
                }
                if (player1SelectedImage == CharacterButtons[1])
                {
                    gameManager.setPlayer1(colorCharacters[7]);
                }
                if (player1SelectedImage == CharacterButtons[2])
                {
                    gameManager.setPlayer1(colorCharacters[4]);
                }
            }
            if (player1Color == Colors.red)
            {
                if (player1SelectedImage == CharacterButtons[0])
                {
                    gameManager.setPlayer1(colorCharacters[2]);
                }
                if (player1SelectedImage == CharacterButtons[1])
                {
                    gameManager.setPlayer1(colorCharacters[8]);
                }
                if (player1SelectedImage == CharacterButtons[2])
                {
                    gameManager.setPlayer1(colorCharacters[5]);
                }
            }
            if (player2Color == Colors.blue)
            {
                if (player2SelectedImage == CharacterButtons[3])
                {
                    gameManager.setPlayer2(colorCharacters[0]);
                }
                if (player2SelectedImage == CharacterButtons[4])
                {
                    gameManager.setPlayer2(colorCharacters[6]);
                }
                if (player2SelectedImage == CharacterButtons[5])
                {
                    gameManager.setPlayer2(colorCharacters[3]);
                }
            }
            if (player2Color == Colors.purple)
            {
                if (player2SelectedImage == CharacterButtons[3])
                {
                    gameManager.setPlayer2(colorCharacters[1]);
                }
                if (player2SelectedImage == CharacterButtons[4])
                {
                    gameManager.setPlayer2(colorCharacters[7]);
                }
                if (player2SelectedImage == CharacterButtons[5])
                {
                    gameManager.setPlayer2(colorCharacters[4]);
                }
            }
            if (player2Color == Colors.red)
            {
                if (player2SelectedImage == CharacterButtons[3])
                {
                    gameManager.setPlayer2(colorCharacters[2]);
                }
                if (player2SelectedImage == CharacterButtons[4])
                {
                    gameManager.setPlayer2(colorCharacters[8]);
                }
                if (player2SelectedImage == CharacterButtons[5])
                {
                    gameManager.setPlayer2(colorCharacters[5]);
                }
            }

            SceneManager.LoadScene("Trip");
        }
    }
    public void Black(int player)
    {
        if(player == 1)
        {
            player1Color = Colors.black;
        }
        else
        {
            player2Color = Colors.black;
        }
    }
    public void purple(int player)
    {
        if (player == 1)
        {
            player1Color = Colors.purple;
        }
        else
        {
            player2Color = Colors.purple;
        }
    }
    public void red(int player)
    {
        if (player == 1)
        {
            player1Color = Colors.red;
        }
        else
        {
            player2Color = Colors.red;
        }
    }
    public void blue(int player)
    {
        if (player == 1)
        {
            player1Color = Colors.blue;
        }
        else
        {
            player2Color = Colors.blue;
        }
    }

    public void Quit()
    {
        ClickSound.Play();
        Application.Quit();
        print("quit application");
    }

    #endregion

}
