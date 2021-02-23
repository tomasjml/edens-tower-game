using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public SaveAndLoad saveAndLoad;

    // Start is called before the first frame update
    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if(SaveAndLoad.instance == null)
        {
            Instantiate(saveAndLoad);
        }
    }
}
