using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject text;
    public GameObject instruction;
    [SerializeField] string scene;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            text.SetActive(false);
            instruction.SetActive(false);
            SceneManager.LoadScene(scene);      
        }

    }

}
