using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaosObjects : MonoBehaviour
{
    [Header("Twisted Zone")]
    public GameObject _Player;
    public GameObject TP_Site;
    int cant = 0;
    int hp;
    public GameObject Fase_1;
    public GameObject deadObject;
    // Update is called once per frame
    void Update()
    {
        hp = GetComponent<BossHealth>().getCurrentHealthEnemy();

        if(hp <= 10 && (gameObject.CompareTag("Twisted") || gameObject.CompareTag("Kaos")))
        {
            if(cant < 1)
            {
                _Player.transform.position = TP_Site.transform.position;
                Fase_1.SetActive(true);
                cant++;
            }
            
        }
        else
        if(hp <=10)
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
