using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject generalSettings;
    public GameObject MusicRoom;
    public GameObject Highscores;

    public void changeSection(int section)
    {
        if (section == 1)
        {
            generalSettings.SetActive(false);
            MusicRoom.SetActive(true);
        }
        else if (section == 2)
        {
            generalSettings.SetActive(false);
            Highscores.SetActive(true);
        }
        else
        {
            MusicRoom.SetActive(false);
            Highscores.SetActive(false);
            generalSettings.SetActive(true);
        }
    }
    public void audioChange(float volume)
    {
        
    }

    public void FullscreeenToggle()
    {
        if (Screen.fullScreenMode.Equals(FullScreenMode.ExclusiveFullScreen))
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
    }

}
