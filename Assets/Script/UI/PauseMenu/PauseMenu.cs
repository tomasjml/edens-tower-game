using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseBtns;
    public GameObject slotsBtns;
    public static bool gameIsPaused = false;
    private Button slot1;
    private Button slot2;
    private Button slot3;
    private Button slot4;

    void Awake()
    {
        slot1 = slotsBtns.transform.Find("Slot1").GetComponent<Button>();
        slot2 = slotsBtns.transform.Find("Slot2").GetComponent<Button>();
        slot3 = slotsBtns.transform.Find("Slot3").GetComponent<Button>();
        slot4 = slotsBtns.transform.Find("Slot4").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadSlots()
    {
        slotsBtns.SetActive(true);
        pauseBtns.SetActive(false);
    }

    public void SlotsBackToPause()
    {
        slotsBtns.SetActive(false);
        pauseBtns.SetActive(true);
    }

    public void AddSaveListeners()
    {

        slot1.onClick.RemoveAllListeners();
        slot2.onClick.RemoveAllListeners();
        slot3.onClick.RemoveAllListeners();
        slot4.onClick.RemoveAllListeners();

        SaveAndLoad temp;
        slot1.onClick.AddListener(() => {GameManager.instance.SaveGame("One"); SaveAndLoad.instance.LoadUserGame();});
        slot2.onClick.AddListener(() => {GameManager.instance.SaveGame("Two"); SaveAndLoad.instance.LoadUserGame();});
        slot3.onClick.AddListener(() => {GameManager.instance.SaveGame("Three"); SaveAndLoad.instance.LoadUserGame();});
        slot4.onClick.AddListener(() => {GameManager.instance.SaveGame("Four"); SaveAndLoad.instance.LoadUserGame();});


    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
