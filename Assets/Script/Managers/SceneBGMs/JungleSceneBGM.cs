using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleSceneBGM : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicJungle);
    }
    
}
