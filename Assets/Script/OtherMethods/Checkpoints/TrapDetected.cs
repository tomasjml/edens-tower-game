using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetected : MonoBehaviour
{
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = GetComponent<SavePoint>().GetLastPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerHealth>().getCurrentHealth() > 1)
            {
                collision.gameObject.transform.position = newPosition;
            }
            Debug.Log("No tiene vidas");
        }
    }
}
