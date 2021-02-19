using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJump : MonoBehaviour
{
    public GameObject instruction;
    public Transform position;

    private GameObject instantiatedObject;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Invoke("DestroyO", 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!jump)
            {
                instantiatedObject = Instantiate(instruction, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
                jump = true;
            }

        }
    }
    void DestroyO()
    {
        DestroyImmediate(instantiatedObject, true);
    }
}
