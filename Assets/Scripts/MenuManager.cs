using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Drawing draw;
    public GameObject StartButtons;
    public GameObject OptionButtons;
    public GameObject GameStartButtons;
    private GameManager gameManager;
    public Animator camAnim;
    public GameObject CharacterSelectButtons;
    public Image[] CharacterButtons;
    public Image[] ColorButtons;
    public GameObject[] colorCharacters;
    private bool Player1Selected = false;
    private Image player1SelectedImage;
    private bool Player2Selected = false;
    private bool Player1SelectedColor = false;
    private Image Player1ColorSelected;
    private Image Player2ColorSelected;
    private bool Player2SelectedColor = false;
    private Image player2SelectedImage;
    public AudioClip[] Openings;
    public AudioSource Opening;
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
        var rand = Random.Range(0, Openings.Length-1);
        print(rand);
        Opening.clip = Openings[rand];
        Opening.Play();
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
        draw.swapCanDraw();
    }
    public void StartLocal(Text button)
    {
        GameStartButtons.SetActive(false);
        CharacterSelectButtons.SetActive(true);
        gameManager.SetGameType(0);
        button.color = baseColor;
        ClickSound.Play();
        camAnim.SetTrigger("backgroundslide");
        draw.swapCanDraw();
    }
    public void LeaveCharacterSelect(Text button)
    {
        button.color = baseColor;
        ClickSound.Play();
        camAnim.SetTrigger("reverseslide");
        GameStartButtons.SetActive(true);
        CharacterSelectButtons.SetActive(false);
        draw.swapCanDraw();
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
        ClickSound.Play();
        if (player == 1)
        {
            if (Player1SelectedColor)
            {
                Player1ColorSelected.color = Color.clear;
                Player1SelectedColor = false;
            }
            player1Color = Colors.black;
            ColorButtons[3].color = Color.yellow;
            Player1ColorSelected = ColorButtons[3];
            Player1SelectedColor = true;
        }
        if(player == 0)
        {
            if (Player2SelectedColor)
            {
                Player2ColorSelected.color = Color.clear;
                Player2SelectedColor = false;
            }
            player2Color = Colors.black;
            ColorButtons[7].color = Color.yellow;
            Player2SelectedColor = true;
            Player2ColorSelected = ColorButtons[7];
        }
    }
    public void purple(int player)
    {
        ClickSound.Play();
        if (player == 1)
        {
            if (Player1SelectedColor)
            {
                Player1ColorSelected.color = Color.clear;
                Player1SelectedColor = false;
            }
            player1Color = Colors.purple;
            ColorButtons[2].color = Color.yellow;
            Player1ColorSelected = ColorButtons[2];
            Player1SelectedColor = true;
        }
        if (player == 0)
        {
            if (Player2SelectedColor)
            {
                Player2ColorSelected.color = Color.clear;
                Player2SelectedColor = false;
            }
            player2Color = Colors.purple;
            ColorButtons[6].color = Color.yellow;
            Player2SelectedColor = true;
            Player2ColorSelected = ColorButtons[6];
        }
    }
    public void red(int player)
    {
        ClickSound.Play();
        if (player == 1)
        {
            if (Player1SelectedColor)
            {
                Player1ColorSelected.color = Color.clear;
                Player1SelectedColor = false;
            }
            player1Color = Colors.red;
            ColorButtons[1].color = Color.yellow;
            Player1ColorSelected = ColorButtons[1];
            Player1SelectedColor = true;
        }
        if (player == 0)
        {
            if (Player2SelectedColor)
            {
                Player2ColorSelected.color = Color.clear;
                Player2SelectedColor = false;
            }
            player2Color = Colors.red;
            ColorButtons[5].color = Color.yellow;
            Player2SelectedColor = true;
            Player2ColorSelected = ColorButtons[5];
        }
    }
    public void blue(int player)
    {
        ClickSound.Play();
        if (player == 1)
        {
            if (Player1SelectedColor)
            {
                Player1ColorSelected.color = Color.clear;
                Player1SelectedColor = false;
            }
            player1Color = Colors.blue;
            ColorButtons[0].color = Color.yellow;
            Player1ColorSelected = ColorButtons[0];
            Player1SelectedColor = true;
        }
        if (player == 0)
        {
            if (Player2SelectedColor)
            {
                Player2ColorSelected.color = Color.clear;
                Player2SelectedColor = false;
            }
            player2Color = Colors.blue;
            ColorButtons[4].color = Color.yellow;
            Player2SelectedColor = true;
            Player2ColorSelected = ColorButtons[4];
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
