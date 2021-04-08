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
        AudioManager.instance.asBGM.volume = settingsMenu.GetComponent<SettingsMenu>().bgmSlidder.value;
    }
}
