using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string _Scene;

    public void LoadSceneY()
    {
        SceneManager.LoadScene(_Scene);
        //GameManager.instance.LoadRequest("One");
        gameObject.SetActive(false);
    }

    public void LoadSceneN()
    {
        SceneManager.LoadScene("Main Menu");
        gameObject.SetActive(false);
    }
}
