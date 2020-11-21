using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject StartButtons;
    public GameObject OptionButtons;

    private Color baseColor = Color.black;
    private Color hoverColor = Color.red;


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
    }
    public void LeaveOptions(Text button)
    {
        OptionButtons.SetActive(false);
        StartButtons.SetActive(true);
        button.color = baseColor;
    }

    public void Quit()
    {
        Application.Quit();
    }

    #endregion

}
