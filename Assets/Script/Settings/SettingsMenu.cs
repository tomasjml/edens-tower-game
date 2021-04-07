using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject generalSettings;
    public GameObject MusicRoom;
    public GameObject Highscores;

    public enum _Resolution
    {
        _1024x768,
        _1280x1024,
        _1920x1080,
        _3840x2160
    }

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
    public void BGMChange()
    {
        
    }

    public void SEChange()
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

    public void resolutionChange()
    {

    }
}
