using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdvice : MonoBehaviour
{
    public GameObject instruction;
    public Transform position;
    private GameObject instanciatedObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instanciatedObject = Instantiate(instruction, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform);
            GameObject.FindGameObjectWithTag("Pause").GetComponent<Inventory>().enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && instanciatedObject)
        {
            Destroy(instanciatedObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.I) && instanciatedObject)
        {
            Destroy(instanciatedObject);
            Destroy(gameObject);
        }
    }
}
