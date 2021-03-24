using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction1 : MonoBehaviour
{
    public GameObject first;
    public Transform position;
    private GameObject instantiatedObject;

    private void Awake()
    {
        Debug.Log("sdsd");
    }
    // Start is called before the first frame update
    void Start()
    {
            instantiatedObject = Instantiate(first, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (instantiatedObject)
            {
                instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
            }
            Invoke("DestroyO", 1);
        }

    }

    void DestroyO()
    {
        DestroyImmediate(instantiatedObject, true);
    }

}
