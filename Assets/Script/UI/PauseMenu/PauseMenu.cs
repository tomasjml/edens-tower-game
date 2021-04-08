using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject HUD;
    public GameObject pausePanel;
    public GameObject Dialogs;
    public GameObject pauseBtns;
    public GameObject slotsBtns;
    public static bool gameIsPaused = false;
    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    //private SaveAndLoad saveObject = null;

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                gameIsPaused = true;
                Pause();
            }
            else if (gameIsPaused)
            {
                gameIsPaused = false;
                Resume();      
            }
            
        }
    }

    public void Resume()
    {
        player.GetComponent<PlayerControllerV2>().enabled = true;
        HUD.SetActive(true);
        pausePanel.SetActive(false);
        if (Dialogs)
        {
            Dialogs.SetActive(true);
        }
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        player.GetComponent<PlayerControllerV2>().enabled = false;
        HUD.SetActive(false);
        if (Dialogs)
        {
            Dialogs.SetActive(false);
        }
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
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
