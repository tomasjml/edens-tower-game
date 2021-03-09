using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObject : MonoBehaviour
{
    // Objeto que va a aparecer
    public GameObject _ObjetoAparecer;
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _ObjetoAparecer.SetActive(true);
        }
    }
}
