using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFirstEnemy : MonoBehaviour
{
    Transform target;
    Transform enemyTransform;
    public float speed = 1f;
    private bool facingRight;
    public float followingDistance = 1f;
    public float attackingDistance = 0.2f;
    public bool shouldAttack = false;
    public float aimingTime = 0.2f;
    public float attackTime = 1.3f;

    private Rigidbody2D _rigidbody;
    Animator _animator;
    public bool shouldStandUp=true;
    private int cantVecesStandUp=0;
    public GameObject magicBall;
    public float launchForce;


    private void Awake()
    {
        enemyTransform = this.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {   
        //_animator.SetBool("idleDowm", true);
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

        target = GameObject.FindWithTag("Player").transform; //Finds the player in any place of the map
        float distance = target.transform.position.x - transform.position.x; //Gets their distance
        //Debug.Log("hi distance "+distance);
        if(shouldAttack == false)
        {
            moving(distance);
        }
        if(shouldStandUp==true &&cantVecesStandUp==0){
            _animator.SetBool("testing",true);
            cantVecesStandUp++;
        }
        if(cantVecesStandUp==1){
            //_animator.SetBool("testing",false);
            _animator.SetBool("idle", _rigidbody.velocity == Vector2.zero);
        }
    }

    private void LateUpdate() 
    {
        //_animator.SetBool("idle", _rigidbody.velocity == Vector2.zero);
    }

    private void moving(float distance)
    {

        if (distance < 0) //If the distance is negative
        {
            distance = distance * -1f; //We make it postive
        }

        if (distance < followingDistance)
        {
            Vector3 targetHeading = target.position - transform.position;
            Vector3 targetDirection = targetHeading.normalized;

            //Rotate to look at the player

            if (facingRight == false) //If the enemy is facing left
            {
                if (target.transform.position.x > transform.position.x) //And the player is on the right side
                {
                    flip();
                }
            }
            if (facingRight == true) //If the enemy is facing right 
            {
                if (target.transform.position.x < transform.position.x) //And the player is on the left side
                {
                    flip();
                }
            }

            float horizontalVelocity = speed; 

            if (facingRight == false) //If the enemy is facing left we have to change the speed to face left
            {
                horizontalVelocity = horizontalVelocity * -1f;
            }

            if (shouldAttack == false && distance <= attackingDistance) //If the enemy is not attacking and the player is in the trigger
            {
                Debug.Log(attackingDistance);
                StartCoroutine(Attack()); //Attack
            }

            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y); //The enemy moves.
        }
    }
    public void flip() //Makes the enemy face the other way 
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private IEnumerator Attack()
    {
        float speedBackup = speed;
        speed = 0f;
        shouldAttack = true;

        yield return new WaitForSeconds(aimingTime);
        Debug.Log("hey shoot");
        _animator.SetTrigger("shoot");
        Shoot();
        yield return new WaitForSeconds(attackTime);

        shouldAttack = false;
        speed = speedBackup;
    }
    void Shoot(){
        GameObject ballIns= Instantiate(magicBall,transform.position,transform.rotation);
        //ballIns.GetComponent<Rigidbody2D>().AddForce(transform.right*launchForce);
        ballIns.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * launchForce *-1, ballIns.GetComponent<Rigidbody2D>().velocity.y);
    }
}
