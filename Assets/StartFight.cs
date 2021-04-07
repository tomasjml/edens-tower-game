using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public GameObject _camaraSystem;
    public GameObject limit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            limit.SetActive(true);
            GameObject.FindGameObjectWithTag("Camera").SetActive(false);
            _camaraSystem.SetActive(true);
            gameObject.GetComponent<DialogManagerV4>().StartDialogue();
        }

    }
}
