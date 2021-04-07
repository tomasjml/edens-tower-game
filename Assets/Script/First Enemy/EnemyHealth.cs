using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int totalHealth = 3;

	private int health;

	private SpriteRenderer _renderer;
	private Animator _animator;

	[Header("Barra de Vida")]
	public UnityEngine.UI.Image barraRoja;
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
		healthBarObject.SetActive(false);
	}
	void UpdateHealthBar()
    {
		healthBarScale.x = healthPercent * health;
		healthBar.localScale = healthBarScale;
    }
    private void FixedUpdate()
    {
		actualizarDisplay(); 
    }

	void actualizarDisplay()
    {
		barraRoja.fillAmount = (float)health / totalHealth;
	}
    public void AddDamageEnemy(int amount)
	{
		healthBarObject.SetActive(true);
		health = health - amount;
		UpdateHealthBar();

		// Visual Feedback
		StartCoroutine("VisualFeedback");
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

