using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Transform target;
    Transform enemyTransform;
    public float speed = 3f;
    private bool facingRight;

    private Rigidbody2D _rigidbody;
    Animator _animator;


    private void Awake()
    {
        enemyTransform = this.GetComponent<Transform>();
        _animator = this.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {   
        _animator.SetBool("Idle", true);
        if (transform.localScale.x < 0f)
        {
            facingRight = false;
        }
        else if (transform.localScale.x > 0f)
        {
            facingRight = true;
        }
    }

    void Update()
    {

        target = GameObject.FindWithTag("Player").transform;
        float distance = target.transform.position.x - transform.position.x;
        if(distance < 0)
        {
            distance = distance * -1f;
        }

        if (distance < 1f)
        {
            Vector3 targetHeading = target.position - transform.position;
            Vector3 targetDirection = targetHeading.normalized;

            //rotate to look at the player

            if (facingRight == false)
            {
                if(target.transform.position.x > transform.position.x)
                {
                    flip();
                }
            }
            if (facingRight == true)
            {
                if (target.transform.position.x < transform.position.x)
                {
                    flip();
                }
            }

            float horizontalVelocity = speed;

            if (facingRight == false)
            {
                horizontalVelocity = horizontalVelocity * -1f;
            }

            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);

        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
    }

    public void flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}