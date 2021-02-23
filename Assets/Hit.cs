using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Se esta dando");
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Se dio");
                collision.SendMessageUpwards("AddDamage", damage);
            }
    }
}
