using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class leaveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collide)
    {    
        if(collide.collider.gameObject.name== "EndScene"){
            foreach(Collider2D c in GetComponents<Collider2D> ()) {
                c.enabled = false;}
            SceneManager.LoadScene("Castillo");
            
        }   
    }
}
