using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("AutoGuardado");
            GameManager.instance.SaveGame("One");
            Destroy(gameObject);
        }

    }
}
