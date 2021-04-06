using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject limits;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.Equals(limits)){
            Physics2D.IgnoreCollision(limits.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
