using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHit : MonoBehaviour
{
    

	private bool _isAttacking=true;
	//private Animator _animator;
	public int damage = 1;
	private Animator _animator;
	public GameObject player;

	private void Start(){
		_animator=player.gameObject.GetComponent<Animator>();
	}

	private void Awake()
	{
        //_animator = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")==false)
		{
			if (collision.gameObject.tag == "Player")
			{
                Debug.Log(collision.gameObject.layer);
				var pos = transform.position;
     			pos.x += 3;
     			transform.position = pos;
				//transform.position=new Vector3(10 * Time.deltaTime , 0, 0);
				collision.SendMessageUpwards("AddDamage", damage);
			}

		}
	}



}
