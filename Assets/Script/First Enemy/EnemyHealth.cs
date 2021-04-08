using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[Header("Vida del Enemigo")]
	public int totalHealth = 3;

	[Header("NO TOCAR")]
	public  int health;
	private int bHealth;
	private SpriteRenderer _renderer;
	private Animator _animator;

	[Header("Barra de Vida")]
	public Transform healthBar; // Barra Roja
	public GameObject healthBarObject;

	private Vector3 healthBarScale;	//Tamaño de la barra
	private float healthPercent;	//Porciento de la vida

	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
	}

	void Start()
	{
		health = totalHealth;
		healthBarScale = healthBar.localScale;
		healthPercent = healthBarScale.x / health;
		
	}
	void UpdateHealthBar()
    {
		healthBarScale.x = healthPercent * health;
		healthBar.localScale = healthBarScale;
    }
    private void Update()
    {
		UpdateHealthBar();
	}

    public void AddDamageEnemy(int amount)
	{
		
		health = health - amount;
		UpdateHealthBar();
		

		// Visual Feedback
		//StartCoroutine("VisualFeedback");
		Debug.Log("Se esta recibiendo");

		// Game  Over
		if (health <= 0)
		{
			
			health = 0;
			StartCoroutine("Died");
		}

		Debug.Log("Enemy got damaged. His current health is " + health);
		
	}

	private IEnumerator VisualFeedback()
	{
		_animator.SetTrigger("isDamaged");

		yield return new WaitForSeconds(0.7f);
	}

	private IEnumerator Died()
    {
		_animator.SetTrigger("Died");

		yield return new WaitForSeconds(1f);

		gameObject.SetActive(false);
		switch (GameManager.instance.saveData.difficulty)
		{
			case SaveData.Difficulty.Easy:
				GameManager.instance.saveData.playerData.AddPoints(5);
				break;
			case SaveData.Difficulty.Normal:
				GameManager.instance.saveData.playerData.AddPoints(10);
				break;
			case SaveData.Difficulty.Hard:
				GameManager.instance.saveData.playerData.AddPoints(15);
				break;
			case SaveData.Difficulty.Hell:
				GameManager.instance.saveData.playerData.AddPoints(20);
				break;
		}
		//Destroy(gameObject,2f);
	}

	public int getCurrentHealthEnemy()
	{
		return health;
	}

	public int totalHealthEnemy()
	{
		return health;
	}
	
}

