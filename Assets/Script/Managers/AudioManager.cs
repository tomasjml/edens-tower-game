using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;
    public AudioClip audioClipMenu;
    public AudioSource asbackgroundMusicMenu;
    public AudioSource asBackgroundMusicHouse;
    public AudioSource asBackgroundMusicJungle;
    public AudioSource asBackgroundMusicTowerEntry;
    public AudioSource asBackgroundMusicScene2;
    public AudioSource asBackgroundMusicExtra1;
    public AudioSource asSoundEffectPlayerWalking;
    public AudioSource asSoundEffectPlayerRunning;
    public AudioSource asSoundEffectPlayerBasicSwordFire;
    public AudioSource asSoundEffectPlayerBasicBowFire;
    public AudioSource asSoundEffectPlayerGameOver;
    public AudioSource asSoundEffectPlayerHurt1;
    public AudioSource asSoundEffectPlayerHurt2;

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
                asbackgroundMusicMenu.Play();
                break;
            case BackgroundMusic.BackgroundMusicHouse:
                asBackgroundMusicHouse.Play();
                break;
            case BackgroundMusic.BackgroundMusicJungle:
                asBackgroundMusicJungle.Play();
                break;
            case BackgroundMusic.BackgroundMusicTowerEntry:
                asBackgroundMusicTowerEntry.Play();
                break;
            case BackgroundMusic.BackgroundMusicScene2:
                asBackgroundMusicScene2.Play();
                break;
            case BackgroundMusic.BackgroundMusicExtra1:
                asBackgroundMusicExtra1.Play();
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
                asSoundEffectPlayerWalking.Play();
                break;
            case SoundEffect.PlayerRunning:
                asSoundEffectPlayerRunning.Play();
                break;
            case SoundEffect.PlayerBasicSwordFire:
                asSoundEffectPlayerBasicSwordFire.Play();
                break;
            case SoundEffect.PlayerBasicBowFire:
                asSoundEffectPlayerBasicBowFire.Play();
                break;
            case SoundEffect.PlayerHurt1:
                asSoundEffectPlayerHurt1.Play();
                break;
            case SoundEffect.PlayerHurt2:
                asSoundEffectPlayerHurt2.Play();
                break;
            case SoundEffect.PlayerGameOver:
                asSoundEffectPlayerGameOver.Play();
                break;
        }
        yield return null;
    }
}
