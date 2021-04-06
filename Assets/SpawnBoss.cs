using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    int hp;
    public GameObject babyEnemies;

    // Update is called once per frame
    void Update()
    {
        hp = GetComponentInParent<EnemyHealth>().getCurrentHealthEnemy();

        if( hp == 15)
        {
            babyEnemies.SetActive(true);
        }
    }
}
