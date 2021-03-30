using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider GammaSlider;
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

    public void GammaChange()
    {
        Screen.brightness = GammaSlider.value;
    }
}
