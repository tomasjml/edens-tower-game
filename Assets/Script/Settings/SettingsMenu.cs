using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject generalSettings;
    public GameObject MusicRoom;
    public GameObject Highscores;
    public Toggle bgmToggle;
    public Slider bgmSlidder;
    public Toggle seToggle;
    public Slider seSlidder;
    public Toggle autoSaveToggle;
    public Toggle _fullscreen;
    public Toggle gammaToggle;
    public Slider gammaSlider;

    public void Start()
    {
        bgmToggle.onValueChanged.AddListener((value) =>
        {
            GameManager.instance.saveData.bgmEnabled = value;
        });
        gammaSlider.onValueChanged.AddListener((value) =>
        {
            RenderSettings.ambientLight = new Color(value, value, value, value);
        });
    }

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

    public void BGMToggle()
    {
        GameManager.instance.saveData.bgmEnabled = bgmToggle.isOn;
    }

    public void BGMChange()
    {
        GameManager.instance.saveData.bgmLvl = (int)(bgmSlidder.value * 100);
    }

    public void SEToggle()
    {
        GameManager.instance.saveData.seEnabled = seToggle.isOn;
    }

    public void SEChange()
    {
        GameManager.instance.saveData.seLvl = (int)(seSlidder.value * 100);
    }

    public void FullscreeenToggle()
    {
        GameManager.instance.saveData.Fullscreen = _fullscreen.isOn;
        if (Screen.fullScreenMode.Equals(FullScreenMode.ExclusiveFullScreen))
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
    }

    public void resolutionChange(int res)
    {
        switch (res)
        {
            case 1:
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(3840, 2160, Screen.fullScreen);
                break;
        }
    }

    public void autosaveToggle()
    {
        GameManager.instance.saveData.autoSave = autoSaveToggle.isOn;
    }
}
