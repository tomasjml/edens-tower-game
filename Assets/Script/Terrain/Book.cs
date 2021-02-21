using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private string nextlevel;
    public GameObject fakeLuke;
    public float time;
    public Animator _animator;

    void Start()
    {
        
    }
    
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fakeLuke.SetActive(true);
            Destroy(other.gameObject);
            //other.gameObject.GetComponent<Animator>().SetBool("Idle", true);
            new WaitForSeconds(10);
        }

        if (other.CompareTag("Bot"))
        {
            
            other.gameObject.GetComponent<Animator>().SetTrigger("Vanish");
            
            _animator.GetComponent<Animator>().SetTrigger("Flotando");
            _animator.GetComponent<Animator>().SetTrigger("Closing");
            Invoke("changeScene",time);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeScene()
    {
        SceneManager.LoadScene(nextlevel);
    }

    void emptySc()
    {

    }
}
