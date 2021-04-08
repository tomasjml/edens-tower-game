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
    public GameObject DifficultyButtons;

    SaveData.Difficulty _diff;

    // Start is called before the first frame update
    void Start()
    {
        MenuButtons.SetActive(true);
        LoadButtons.SetActive(false);
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
        GameManager.instance.NewGame(_diff, SettingsMenu);

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

    public void MainToLoadButton()
    {
        MenuButtons.SetActive(false);
        LoadButtons.SetActive(true);
        DifficultyButtons.SetActive(false);
    }

    public void LoadToMainButton()
    {
        MenuButtons.SetActive(true);
        LoadButtons.SetActive(false);
    }

    public void difficultyButton()
    {
        LoadButtons.SetActive(false);
        DifficultyButtons.SetActive(true);
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

    public void setDiff(int diff)
    {
        switch (diff)
        {
            case 1:
                _diff = SaveData.Difficulty.Easy;
                break;
            case 2:
                _diff = SaveData.Difficulty.Normal;
                break;
            case 3:
                _diff = SaveData.Difficulty.Hard;
                break;
            case 4:
                _diff = SaveData.Difficulty.Hell;
                break;
            default:
                break;
        }
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}