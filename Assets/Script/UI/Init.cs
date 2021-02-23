using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject text;
    [SerializeField] string scene;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
                text.SetActive(false);
                SceneManager.LoadScene(scene);      
        }

    }

}
