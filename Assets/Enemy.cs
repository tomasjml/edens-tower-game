using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2f;
    public bool hasTarget = false;
    public GameObject target;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("PlayerObject"))
        {    // is the other object the player
            target = other.gameObject;      // it is so set him as my target
            hasTarget = true;   // I have a target
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            //get distance between me and my target
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // am I further than 2 units away
            if (distance > 2)
            {
                // I am over 2 units away
                follow(target.transform); // do a follow
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("PlayerObject"))
        {
            target = null;
            hasTarget = false;
        }
    }

    private void follow(Transform target)
    {
        // add force to my rigid body to make me move
        rb.AddForce((target.transform.position - transform.position).normalized * speed);
    }
}
