using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarEnemy : MonoBehaviour
{
    public UnityEngine.UI.Image barraRoja;
    int currentHealth = 0;
    int totalHealth = 0;

    private void Start()
    {
        totalHealth = GetComponent<EnemyHealth>().totalHealthEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        currentHealth = GetComponent<EnemyHealth>().getCurrentHealthEnemy();
        actualizarBarra();
    }

    void actualizarBarra()
    {
        barraRoja.fillAmount = (float)currentHealth / totalHealth;
    }
}
