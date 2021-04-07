using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2BGM : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicScene2);
    }
}
