using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class TaskLoader : MonoBehaviour
{
    public Vector3 startPosition;
    public GameObject[] tasks;
    public Transform[] positions;
    public GameObject[] triggers;

    private GameObject player;
    private GameObject instantiatedObject0 = null;
    private GameObject instantiatedObject1 = null;
    private GameObject instantiatedObject2 = null;
    private string scene;


    private void Awake()
    {
        scene = SceneManager.GetActiveScene().name;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        if(player && player.transform.position.x > startPosition.x)
        {
            foreach(GameObject t in triggers)
            {
                if(t.transform.position.x < player.transform.position.x)
                {
                    Destroy(t);
                }
            }
            try
            {
                instantiatedObject0 = Instantiate(tasks[0], positions[0].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                instantiatedObject1 = Instantiate(tasks[1], positions[1].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                instantiatedObject2 = Instantiate(tasks[2], positions[2].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedObject0 && !instantiatedObject0.GetComponent<Animator>().GetBool("Appear"))
        {
            try
             {
                    instantiatedObject1.GetComponent<Animator>().SetBool("Appear", true);
                    instantiatedObject2.GetComponent<Animator>().SetBool("Appear", true);
                    instantiatedObject0.GetComponent<Animator>().SetBool("Appear", true);
             }
             catch (NullReferenceException)
            {

            }
        }
        
        if (scene.Equals("Dormitorio Luke"))
        {
            instantiatedObject1.GetComponent<Animator>().SetTrigger("Complete");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!instantiatedObject0)
            {
                try
                {
                    instantiatedObject0 = Instantiate(tasks[0], positions[0].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                    instantiatedObject1 = Instantiate(tasks[1], positions[1].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                    instantiatedObject2 = Instantiate(tasks[2], positions[2].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                }
                catch (IndexOutOfRangeException)
                {

                }
            }
        }

    }

}
