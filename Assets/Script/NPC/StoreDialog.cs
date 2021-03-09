using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StoreDialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public Canvas canvas;
    public Canvas store;

    private void Start()
    {
        ShowSentence();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentence();
        }
    }

    public void ShowSentence()
    {
        textDisplay.text = sentences[index];
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            ShowSentence();
        } else
        {
            textDisplay.text = "";
            canvas.gameObject.SetActive(false);
            store.gameObject.SetActive(true);
        }
    }
}
