using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Main_Menu;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void Play()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Dormitorio Lisa");
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        Main_Menu.SetActive(true);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        Main_Menu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        // Show Credits Menu
        Main_Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}