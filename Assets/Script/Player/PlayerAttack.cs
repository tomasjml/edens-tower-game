using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking;
	private Animator _animator;
	public int strength = 1;
	SpriteRenderer _renderer;

	private void Awake()
	{
		_animator = GetComponentInParent<Animator>();
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
			if (collision.gameObject.layer == 9)
			{
				_renderer = collision.GetComponent<SpriteRenderer>();
				if(collision.CompareTag("BOSSInferno"))
                {
					StartCoroutine(VisualFeedback());
				}
				collision.SendMessageUpwards("AddDamageEnemy", strength);
				Debug.Log("Se esta enviando");
			}

		}
	}

	private IEnumerator VisualFeedback()
	{
		_renderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.white;
	}
}
