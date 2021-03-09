using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Object;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _Object.SetActive(true);
        }
    }
}
