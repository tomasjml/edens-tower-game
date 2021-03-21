using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;
    public AudioClip audioClipMenu;
    public AudioSource asBGMMenu;
    public AudioSource asBGMHouse;
    public AudioSource asBGMJungle;
    public AudioSource asBGMTowerEntry;
    public AudioSource asBGMScene2;
    public AudioSource asBGMExtra1;
    public AudioSource asSEPlayerWalking;
    public AudioSource asSEPlayerRunning;
    public AudioSource asSEPlayerBasicSwordFire;
    public AudioSource asSEPlayerBasicBowFire;
    public AudioSource asSEPlayerGameOver;
    public AudioSource asSEPlayerHurt1;
    public AudioSource asSEPlayerHurt2;

    public enum BackgroundMusic
    {
        BackgroundMusicMenu,
        BackgroundMusicHouse,
        BackgroundMusicJungle,
        BackgroundMusicTowerEntry,
        BackgroundMusicScene2,
        BackgroundMusicExtra1
    }

    public enum SoundEffect
    {
        PlayerWalking,
        PlayerRunning,
        PlayerBasicSwordFire,
        PlayerBasicBowFire,
        PlayerGameOver,
        PlayerHurt1,
        PlayerHurt2
    }

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

    /*IEnumerator PlayingBackgroundMusic()
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
    }*/

    public void PlayBackgroundMusic(BackgroundMusic type)
    {
        StartCoroutine(PlayingBackgroundMusic(type));
    }

    IEnumerator PlayingBackgroundMusic(BackgroundMusic type)
    {
        switch (type)
        {
            case BackgroundMusic.BackgroundMusicMenu:
                asBGMMenu.Play();
                break;
            case BackgroundMusic.BackgroundMusicHouse:
                asBGMHouse.Play();
                break;
            case BackgroundMusic.BackgroundMusicJungle:
                asBGMJungle.Play();
                break;
            case BackgroundMusic.BackgroundMusicTowerEntry:
                asBGMTowerEntry.Play();
                break;
            case BackgroundMusic.BackgroundMusicScene2:
                asBGMScene2.Play();
                break;
            case BackgroundMusic.BackgroundMusicExtra1:
                asBGMExtra1.Play();
                break;
        }
        yield return null;
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        StartCoroutine(PlayingSoundEffect(type));
    }

    IEnumerator PlayingSoundEffect(SoundEffect type)
    {
        switch (type)
        {
            case SoundEffect.PlayerWalking:
                asSEPlayerWalking.Play();
                break;
            case SoundEffect.PlayerRunning:
                asSEPlayerRunning.Play();
                break;
            case SoundEffect.PlayerBasicSwordFire:
                asSEPlayerBasicSwordFire.Play();
                break;
            case SoundEffect.PlayerBasicBowFire:
                asSEPlayerBasicBowFire.Play();
                break;
            case SoundEffect.PlayerHurt1:
                asSEPlayerHurt1.Play();
                break;
            case SoundEffect.PlayerHurt2:
                asSEPlayerHurt2.Play();
                break;
            case SoundEffect.PlayerGameOver:
                asSEPlayerGameOver.Play();
                break;
        }
        yield return null;
    }
}
