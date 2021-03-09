using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokeObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Object_to_Broke;
    public GameObject _Object_Broken;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Catch u bch");
                _Object_to_Broke.GetComponent<Animator>().SetTrigger("Cut");
                _Object_Broken.GetComponent<Animator>().SetTrigger("Cut");
                
            }
        }
    }
}
