using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private string nextlevel;
    public GameObject fakeLuke;
    // Start is called before the first frame update
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
            //SceneManager.LoadScene(nextlevel);
        }

        if (other.CompareTag("Bot"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
