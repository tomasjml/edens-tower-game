using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject limit;
    public GameObject enemy;
    private FlyingEnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth=enemy.gameObject.GetComponent<FlyingEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.gameObject.activeSelf==true ){
            //Debug.Log("es true el primer enemigo");
            transform.gameObject.SetActive(true);
        }
        else{
            //Debug.Log("es false el primer enemigo");
            
            transform.gameObject.SetActive(false);
        }
    }
}
