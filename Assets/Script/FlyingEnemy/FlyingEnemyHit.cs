using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHit : MonoBehaviour
{
    

	private bool _isAttacking=true;
	//private Animator _animator;
	public int damage = 1;

	private void Awake()
	{
        //_animator = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		// Animator
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
        if (_isAttacking)
		{
			if (collision.gameObject.tag == "Player")
			{
                Debug.Log(collision.gameObject.layer);
				transform.position=new Vector3(10 * Time.deltaTime , 0, 0);
				collision.SendMessageUpwards("AddDamage", damage);
			}

		}
	}



}
