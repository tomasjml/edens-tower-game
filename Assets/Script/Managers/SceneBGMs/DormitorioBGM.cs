using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormitorioBGM : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicHouse);
    }
}
