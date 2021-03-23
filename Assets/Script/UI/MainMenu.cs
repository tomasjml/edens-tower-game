using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Main_Menu;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;
    public GameObject LoadButtons;
    public GameObject LoadMenu;
    public GameObject MenuButtons;
    public GameObject Background;

    // Start is called before the first frame update
    void Start()
    {
        MenuButtons.SetActive(true);
        LoadButtons.SetActive(false);
    }

    public void MainToLoadButton()
    {
        MenuButtons.SetActive(false);
        LoadButtons.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu, hide everything else.
        Main_Menu.SetActive(true);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        LoadMenu.SetActive(false);
    }

    public void NewGame()
    {
        GameManager.instance.NewGame();
    }

    public void ResumeGame()
    {
        GameManager.instance.LoadRequest("One");
    }

    public void LoadMenuButton()
    {
        Main_Menu.SetActive(false);
        LoadMenu.SetActive(true);
    }

    public void LoadToMainButton()
    {
        MenuButtons.SetActive(true);
        LoadButtons.SetActive(false);
    }

    public void CreditsButton()
    {
        // Show Credits Menu, hide everything else.
        Main_Menu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        // Show Settings Menu
        Main_Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}