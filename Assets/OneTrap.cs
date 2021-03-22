using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTrap : MonoBehaviour
{
    public GameObject _Trap;
    int aux = 0;

    // Update is called once per frame
    void Update()
    {
        if(aux == 0)
        {
            Instantiate(_Trap, gameObject.transform.position, Quaternion.identity);
            aux++;
        }

        if(gameObject.tag == "Platform")
        {

        }
    }
}
