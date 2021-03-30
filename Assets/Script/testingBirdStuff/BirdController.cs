using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 7;
    private GameObject target;
    private Rigidbody2D rb;
    void Start(){
        rb=GetComponent<Rigidbody2D>();
        target=GameObject.FindWithTag("Player");
    }
     
     
    void Update () {
        float distanceFromPlayer=Vector2.Distance(target.transform.position,transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed*Time.deltaTime);
        
    }

}
