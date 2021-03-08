using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightIgnoreDieCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collisionInfo){
        
        
        if(collisionInfo.collider.gameObject.tag== "Die"){
            foreach(Collider2D c in GetComponents<Collider2D> ()) {
                c.enabled = false;
            }
          
        }
    }
}
