using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseBtns;
    public GameObject slotsBtns;
    public static bool gameIsPaused = false;

   

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

    public void AppQuit()
    {
        Application.Quit();
    }
}
