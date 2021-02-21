using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject player;
    public GameObject first;
    public Transform position;

    private float initial_position;
    private GameObject instantiatedObject;

    private void Awake()
    { 
    }
    // Start is called before the first frame update
    void Start()
    {
            instantiatedObject = Instantiate(first, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
            initial_position = player.transform.position.x;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs((player.transform.position.x - initial_position)) > 0.05)
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
