using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGM : MonoBehaviour
{
    public GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicMenu);
    }

    private void Update()
    {
        // if (AudioManager.instance.asBGM)
        //{
        //    float volume = settingsMenu.GetComponent<SettingsMenu>().bgmSlidder.value;
        //    bool isOn = settingsMenu.GetComponent<SettingsMenu>().bgmToggle.isOn;
        //    AudioManager.instance.asBGM.volume = (isOn == false ? 0f : volume);
        //}
    }
}
