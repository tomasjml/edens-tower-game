using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObjects : MonoBehaviour
{

    // Objeto que va a desaparecer
    public GameObject _ObjetoDesaparecer;
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _ObjetoDesaparecer.SetActive(false);
        }
    }
}
