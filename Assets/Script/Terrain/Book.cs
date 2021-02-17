using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private string nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerControllerV2>().enabled = false;
            //other.gameObject.GetComponent<Animator>().SetBool("Idle", true);
            other.gameObject.GetComponent<Animator>().SetTrigger("Vanish");
            new WaitForSeconds(10);
            //SceneManager.LoadScene(nextlevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
