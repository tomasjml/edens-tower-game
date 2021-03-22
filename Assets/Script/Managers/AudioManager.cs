using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource asBGM;
    public AudioSource asSE;
    public AudioClip acBGMMenu;
    public AudioClip acBGMHouse;
    public AudioClip acBGMJungle;
    public AudioClip acBGMTowerEntry;
    public AudioClip acBGMScene2;
    public AudioClip acBGMExtra1;
    public AudioClip acSEPlayerWalking;
    public AudioClip acSEPlayerRunning;
    public AudioClip acSEPlayerBasicSwordFire;
    public AudioClip acSEPlayerBasicBowFire;
    public AudioClip acSEPlayerGameOver;
    public AudioClip acSEPlayerHurt1;
    public AudioClip acSEPlayerHurt2;


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

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        Instantiate(asBGM.gameObject);
        DontDestroyOnLoad(asBGM.gameObject);
    }

    public void PlayBackgroundMusic(BackgroundMusic type)
    {
        StartCoroutine(PlayingBackgroundMusic(type));
    }

    IEnumerator PlayingBackgroundMusic(BackgroundMusic type)
    {
        switch (type)
        {
            case BackgroundMusic.BackgroundMusicMenu:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMMenu;
                asBGM.Play();
                break;
            case BackgroundMusic.BackgroundMusicHouse:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMHouse;
                asBGM.Play();
                break;
            case BackgroundMusic.BackgroundMusicJungle:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMJungle;
                asBGM.Play();
                break;
            case BackgroundMusic.BackgroundMusicTowerEntry:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMTowerEntry;
                asBGM.Play();
                break;
            case BackgroundMusic.BackgroundMusicScene2:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMScene2;
                asBGM.Play();
                break;
            case BackgroundMusic.BackgroundMusicExtra1:
                if (asBGM.isPlaying)
                {
                    asBGM.Stop();
                }
                asBGM.clip = acBGMExtra1;
                asBGM.Play();
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
                asSE.clip = acSEPlayerWalking;
                asSE.Play();
                break;
            case SoundEffect.PlayerRunning:
                asSE.clip = acSEPlayerRunning;
                asSE.Play();
                break;
            case SoundEffect.PlayerBasicSwordFire:
                asSE.clip = acSEPlayerBasicSwordFire;
                asSE.Play();
                break;
            case SoundEffect.PlayerBasicBowFire:
                asSE.clip = acSEPlayerBasicBowFire;
                asSE.Play();
                break;
            case SoundEffect.PlayerHurt1:
                asSE.clip = acSEPlayerHurt1;
                asSE.Play();
                break;
            case SoundEffect.PlayerHurt2:
                asSE.clip = acSEPlayerHurt2;
                asSE.Play();
                break;
            case SoundEffect.PlayerGameOver:
                asSE.clip = acSEPlayerGameOver;
                asSE.Play();
                break;
        }
        yield return null;
    }

    public void StopAllBackgroundMusic()
    {
        asBGM.Stop();
    }
}
