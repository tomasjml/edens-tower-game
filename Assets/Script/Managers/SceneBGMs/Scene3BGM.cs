using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3BGM : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicScene3);
    }
}
