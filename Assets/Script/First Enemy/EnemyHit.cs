using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
	private bool _isAttacking;
	private Animator _animator;
	public int damage = 1;

	private void Awake()
	{
        _animator = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		// Animator
		if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
		{
			_isAttacking = true;
		}
		else
		{
			_isAttacking = false;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log("sip "+collision.gameObject.gameObject.tag);
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_isAttacking)
		{
			if (collision.gameObject.tag == "Player")
			{
				Debug.Log("Se dio");
				collision.SendMessageUpwards("AddDamage", damage);
			}

		}
	}
}

