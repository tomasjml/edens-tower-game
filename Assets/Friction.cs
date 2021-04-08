using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float frictionCoeficent;
    private Vector3 deltapos = new Vector3();
    private Vector3 Currentspeed = new Vector3();
    private float mass;
    private Animator animator;
    public GameObject player;
    private void Start()
    {
        mass = gameObject.GetComponent<Rigidbody2D>().mass;
        animator = player.gameObject.GetComponent<Animator>();
    }
    private float getFrictionForce()
    {
        float friction = 0;
        friction = frictionCoeficent * getNormalForce();
        return friction;
    } 
    void Update(){
       
        if(animator.GetBool("isPushing")==true){
            deltapos.x = (Currentspeed.x * Time.deltaTime + getAcceleration() * Mathf.Pow(Time.deltaTime, 2)) / 2;
            gameObject.transform.Translate(deltapos);
            Currentspeed += new Vector3(getAcceleration() * Time.deltaTime, 0, 0);

        }
    }

    private float getNormalForce()
    {
        float normal = 0;
        normal = Physics2D.gravity.magnitude * mass;
        return normal;
    }

    private float getAcceleration()
    {

        float acceleration = 0;
        acceleration = getFrictionForce()/ mass;
        return acceleration;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("isPushing", false);
            Currentspeed = new Vector3();
            deltapos = new Vector3();
        }
    }
}
