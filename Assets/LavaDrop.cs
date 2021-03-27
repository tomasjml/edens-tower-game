using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrop : MonoBehaviour
{
    Animator _anim;
    bool p = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        _anim.SetTrigger("splash");
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        Destroy(gameObject, 0.3f);
    }
}
