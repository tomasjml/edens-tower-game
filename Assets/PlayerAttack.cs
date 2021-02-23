using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking;
	private Animator _animator;
	public int strength = 1;

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
		if (_isAttacking)
		{
			if (collision.CompareTag("Enemy"))
			{
				collision.SendMessageUpwards("AddDamageEnemy", strength);
			}

		}
	}
}
