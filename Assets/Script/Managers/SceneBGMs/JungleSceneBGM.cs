using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleSceneBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicJungle);
    }
}
