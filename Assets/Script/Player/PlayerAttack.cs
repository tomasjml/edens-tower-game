using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking;
	[Header("Sonido Hit")]
	public AudioClip _Hit;
	private AudioSource playerHitSFX;
	private Animator _animator;
	public int strength = 1;
	SpriteRenderer _renderer;


	private void Awake()
	{
		_animator = GetComponentInParent<Animator>();
	}
    private void Start()
    {
		playerHitSFX = GetComponentInParent<AudioSource>();

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
				playerHitSFX.PlayOneShot(_Hit, 0.5f);
				_renderer = collision.GetComponent<SpriteRenderer>();
				if (collision.gameObject.CompareTag("MiniSkeleton"))
                {
					
				}
				else if(collision.gameObject.CompareTag("MegaSkeleton"))
                {
					
                }
                else
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
	private IEnumerator VisualFeedbackGreen()
	{
		_renderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.green;
	}
	private IEnumerator VisualFeedbackRed()
	{
		_renderer.color = Color.white;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.red;
	}
}
