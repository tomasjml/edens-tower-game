using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_Script : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    float limDer;
    float limIzq;
    public float _Velocidad_Enemy;
    int direccion = 1;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        limDer = transform.position.x + GetComponent<CircleCollider2D>().radius;
        limIzq = transform.position.x - GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(_Velocidad_Enemy * direccion,rb.velocity.y);
        if(transform.position.x < limIzq) direccion = 1;
        if(transform.position.x > limDer) direccion = -1;
        transform.localScale = new Vector3 (1 * direccion,1,1);
        
        

    }
}
