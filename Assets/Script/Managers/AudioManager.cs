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
        Instantiate(audioSource);
        DontDestroyOnLoad(audioSource);

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
            audioSource.enabled = true;
            Debug.Log("BackgroundMusic State: " + audioSource.isActiveAndEnabled);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
            }
        }
    }

    public void PlayBackgroundMusic()
    {
        StartCoroutine(nameof(BackgroundMusic));
    }
}
