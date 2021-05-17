using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    //public GameObject loadGameScreen;

    private void Start()
    {
        OnMainMenu();
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnMainMenu()
    {
        mainMenu.SetActive(true);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        //loadGameScreen.SetActive(false);
    }
    public void OnOptions()
    {
        mainMenu.SetActive(false);
        optionsScreen.SetActive(true);
        creditsScreen.SetActive(false);
        //loadGameScreen.SetActive(false);
    }
    public void OnCredits()
    {
        mainMenu.SetActive(false);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(true);
        //loadGameScreen.SetActive(false);
    }
    public void OnStartGame()
    {
        mainMenu.SetActive(false);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        //loadGameScreen.SetActive(true);
    }
}
