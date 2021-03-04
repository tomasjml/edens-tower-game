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
    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    //private SaveAndLoad saveObject = null;


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
      //  if (saveObject == null)
      //  {
        //    GameObject gameObject = GameObject.FindGameObjectWithTag("Pause");
       //     saveObject = (SaveAndLoad)gameObject.GetComponent(typeof(SaveAndLoad));
        //}

        slot1.onClick.AddListener(() => {GameManager.instance.SaveGame("One");});
        slot2.onClick.AddListener(() => {GameManager.instance.SaveGame("Two");});
        slot3.onClick.AddListener(() => {GameManager.instance.SaveGame("Three");});
        slot4.onClick.AddListener(() => {GameManager.instance.SaveGame("Four");});


    }

    public void AddLoadListeners()
    {
        slot1.onClick.AddListener(() => { GameManager.instance.LoadRequest("One"); gameIsPaused = false; });
        slot2.onClick.AddListener(() => { GameManager.instance.LoadRequest("Two"); gameIsPaused = false; });
        slot3.onClick.AddListener(() => { GameManager.instance.LoadRequest("Three"); gameIsPaused = false; });
        slot4.onClick.AddListener(() => { GameManager.instance.LoadRequest("Four"); gameIsPaused = false; });
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
