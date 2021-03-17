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

    void DestroyO()
    {
        DestroyImmediate(instantiatedObject, true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!instantiatedObject)
        {
            instantiatedObject = Instantiate(first, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
            initial_position = player.transform.position.x;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
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



}
