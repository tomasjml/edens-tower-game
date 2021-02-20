using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2f;
    public bool hasTarget = false;
    public GameObject target; 

    private Rigidbody2D rb;

    //Movement
    private bool facingLeft;
    private Vector2 movement;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (transform.localScale.x < 0f)
        {
            facingLeft = true;
        }
        else if (transform.localScale.x > 0f)
        {
            facingLeft = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.left;

        if (facingLeft == false)
        {
            direction = Vector2.right;
        }
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
