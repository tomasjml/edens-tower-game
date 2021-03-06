using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject audioManager;
    public SaveAndLoad saveAndLoad;

    // Start is called before the first frame update
    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (AudioManager.instance == null)
        {
            Instantiate(audioManager);
        }


        //if(SaveAndLoad.instance == null)
        //{
          //  Instantiate(saveAndLoad);
        //}
    }
}
