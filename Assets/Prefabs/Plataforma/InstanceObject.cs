using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    public GameObject instanceObject;
    Vector3 deltaPos;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(instanceObject, deltaPos = new Vector3((float)Random.Range(5, 10), Random.Range(5, 15)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if( i < 2 )
        {
            i++;
            
        }
    }
}
