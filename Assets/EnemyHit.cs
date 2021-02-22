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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_isAttacking == true)
		{
			if (collision.CompareTag("Player"))
			{
				collision.SendMessageUpwards("AddDamage", damage);
				Debug.Log("Is being damaged");
			}

		}
	}
}

