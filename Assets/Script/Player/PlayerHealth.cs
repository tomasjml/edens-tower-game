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
	float timePass = 0f;
	float timePassLife = 0f;

	bool medió = false;
	int cant = 0;

	
	private void Awake()
	{
		//totalHealth = GameManager.instance.saveData.playerData.vitality;
		//totalHealth = 20;
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
    private void Update()
    {

		if (health < totalHealth)
		{
			//Debug.Log("La vida es " + health + "de " + totalHealth + "posibles.");
			if (Time.time > timePass)
			{
				if(cant < 1)
                {
					timePass = timeRegenerate();
					cant++;
                }
                else
                {
					if (GameManager.instance == true)
					{
						switch (GameManager.instance.saveData.difficulty)
						{
							case SaveData.Difficulty.Easy:
								if (totalHealth - 4 > health)
								{
									health += 1;
								}
								cant = 0;
								break;
							case SaveData.Difficulty.Normal:
								if (totalHealth - 8 > health)
								{
									health += 1;
								}
								cant = 0;
								break;
							case SaveData.Difficulty.Hard:
								if (totalHealth - 12 > health)
								{
									health += 1;
								}
								cant = 0;
								break;
							case SaveData.Difficulty.Hell:
								if (totalHealth - 16 > health)
								{
									health += 1;
								}
								cant = 0;
								break;
						}
					}else if(totalHealth - 4 > health)
                    {
						health += 1;
                    }
					cant = 0;
					
					Debug.Log("Vida despues de regenerarse " + health);
				}
				
				
			}
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
		Debug.Log(health);
	}

	public int getTotalHealth()
    {
		return totalHealth;
    }

	float timeRegenerate()
	{
		return Time.time + 10f;
	}
}
