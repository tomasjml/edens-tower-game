using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistedON : MonoBehaviour
{
    Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _animator.GetComponentInParent<Animator>().SetTrigger("Twisted");
        }
    }
}
