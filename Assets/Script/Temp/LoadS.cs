using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadS : MonoBehaviour
{

    public string _Scene;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(_Scene);
        }
    }

    public void LoadSceneY()
    {
        SceneManager.LoadScene(GetComponent<Scene>().name);
        gameObject.SetActive(false);
    }

    public void LoadSceneN()
    {
        SceneManager.LoadScene("Main Menu");
        gameObject.SetActive(false);
    }
}
