using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBGM : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        AudioManager.instance.PlayBackgroundMusic(AudioManager.BackgroundMusic.BackgroundMusicHouse);
    }
}
