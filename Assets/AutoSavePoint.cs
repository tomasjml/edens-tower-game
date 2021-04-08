using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameManager.instance.saveData.autoSave " + GameManager.instance.saveData.autoSave.ToString());
        if (other.CompareTag("Player") && GameManager.instance.saveData.autoSave)
        {
            Debug.Log("AutoGuardado");
            GameManager.instance.SaveGame("One");
            Destroy(gameObject);
        }

    }
}
