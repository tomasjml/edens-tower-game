using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	private int totalHealth;

	public GameObject[] hearts;

	private int health;

	private SpriteRenderer _renderer;

	private Animator _animator;

	
	private void Awake()
	{
		//totalHealth = GameManager.instance.saveData.playerData.vitality;
		totalHealth = 10;
		_renderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
	}

	void Start()
	{
        if (GameManager.instance)
        {
			health = GameManager.instance.saveData.playerData.vitality;
			totalHealth = health;
        }
        else
        {
			health = 20;
			totalHealth = health;
		}

	}

	public void AddDamage(int amount)
	{
		health = health - amount;

		// Visual Feedback
		StartCoroutine("VisualFeedback");

		// Game  Over
		if (health <= 0)
		{
			health = 0;
			StartCoroutine("IsDead");
			
		}
		Debug.Log("Player got damaged. His current health is " + health);
	}

	public void AddHealth(int amount)
	{
		health = health + amount;

		// Max health
		if (health > totalHealth)
		{
			health = totalHealth;
		}
		Debug.Log("Player got some life. His current health is " + health);
	}

	private IEnumerator VisualFeedback()
	{
		_renderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.white;
	}

	private IEnumerator IsDead()
    {
		_animator.SetTrigger("IsDead");

		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
		GameManager.instance.EndGame();
		
	}
	public int getCurrentHealth(){
		return health;
	}
	public void setHealth(int hp){
		health = hp;
	}


}
