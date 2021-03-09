using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;
    public AudioClip audioClipMenu;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        // Instantiate AudioSource
        Instantiate(this.audioSource);
        DontDestroyOnLoad(this.audioSource);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       
    }

    IEnumerator BackgroundMusic()
    {
        // TODO while change to condition on menu for Background Music
        while (true)
        {
            audioSource.clip = audioClipMenu;

            if (!audioSource.isPlaying)
            {
                yield return new WaitForSeconds(audioSource.clip.length);
                audioSource.Play();
            }
        }
    }

    public void PlayBackgroundMusic()
    {
        StartCoroutine(nameof(BackgroundMusic));
    }
}
