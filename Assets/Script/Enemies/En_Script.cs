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

    enum comportamientoEnemy { pasivo, persecusion, ataque }

    comportamientoEnemy comp = comportamientoEnemy.pasivo;

    float enPersecusion = 6f; // entrada a la zona de persecusion
    float salPersecusion = 8f; // el enemigo deja de seguirnos
    float zonaAtaque = 1f;

    public Transform _Player;

    float distancePlayer;
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
        distancePlayer = Mathf.Abs(_Player.position.x - transform.position.x);
        switch(comp)
        {
            case comportamientoEnemy.pasivo:
                // caminar
                rb.velocity = new Vector2(_Velocidad_Enemy * direccion,rb.velocity.y);
                //girarse
                if(transform.position.x < limIzq) direccion = 1;
                if(transform.position.x > limDer) direccion = -1;

                // zona persecusion
                if(distancePlayer < enPersecusion) comp = comportamientoEnemy.persecusion;
            break;

            case comportamientoEnemy.persecusion:
                // "correr"
                rb.velocity = new Vector2(_Velocidad_Enemy * 1.5f * direccion,rb.velocity.y);
                //girarse
                if(_Player.position.x > transform.position.x) direccion = 1;
                if(_Player.position.x < transform.position.x) direccion = -1;

                animator.speed = 1.5f;

                // zona pasiva
                if(distancePlayer > salPersecusion) comp = comportamientoEnemy.pasivo;

                //zona ataque
                if(distancePlayer < zonaAtaque) comp = comportamientoEnemy.ataque;
            break;

            case comportamientoEnemy.ataque:
                animator.SetTrigger("IsAttacking");
                
                //girarse
                if(_Player.position.x > transform.position.x) direccion = 1;
                if(_Player.position.x < transform.position.x) direccion = -1;

                animator.speed = 1f;

                

                //zona persecusion
                if(distancePlayer > zonaAtaque)
                {
                     comp = comportamientoEnemy.persecusion;
                     animator.ResetTrigger("IsAttacking");
                }
            break;
        }
        
        transform.localScale = new Vector3 (1 * direccion,1,1);
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && comp == comportamientoEnemy.ataque)
        {
            _Player.GetComponent<HealthPlayer>().Hit();
        }
    }
}
