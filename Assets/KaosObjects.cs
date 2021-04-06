using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaosObjects : MonoBehaviour
{
    int hp;
    public GameObject Fase_1;
    public GameObject deadObject;
    // Update is called once per frame
    void Update()
    {
        hp = GetComponent<EnemyHealth>().getCurrentHealthEnemy();

        if(hp <= 12)
        {
            Fase_1.SetActive(true);
        }

        if(hp <= 0 )
        {
            Fase_1.SetActive(false);
            deadObject.transform.position = gameObject.transform.position;
            Invoke("DeadOb", 1f);
        }
    }

    void DeadOb()
    {
        deadObject.SetActive(true);
    }
}
