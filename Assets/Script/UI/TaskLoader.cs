using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLoader : MonoBehaviour
{
    public GameObject[] tasks;
    public Transform position;

    private GameObject instantiatedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(GameObject o in tasks)
            {
                instantiatedObject = Instantiate(o, position.position+new Vector3(0,2,1), Quaternion.identity, GameObject.FindGameObjectWithTag("Task").transform) as GameObject;
                
            }

        }
    }
}
