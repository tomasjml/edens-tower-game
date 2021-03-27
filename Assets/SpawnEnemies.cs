using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] _Enemies;
    Transform[] padre;
    int aux = 0, hordas = 0;
    public int  cantHordas = 3;

    // Update is called once per frame
    void Update()
    {
        padre = this.transform.GetComponentsInChildren<Transform>();
        if(padre != null)
        {
            if( hordas == 0)
            {
                Invoke("Enemies", 0);
                hordas++;
            }
                
            if( hordas == 1)
            {
                Invoke("Enemies", 0);
                Invoke("Enemies", 0.2f);
                Invoke("Enemies", 0.4f);
                hordas++;
                }

            if(hordas >= 2 && hordas < cantHordas )
            {
                Invoke("Enemies", 0);
                Invoke("Enemies", 0.2f);
                Invoke("Enemies", 0.4f);
                Invoke("Enemies", 0.6f);
                Invoke("Enemies", 0.8f);
                hordas++;
            }
            
        }
    }

    void Enemies()
    {
        Instantiate(_Enemies[Random.Range(0, 4)], this.transform.position, Quaternion.identity);
        
        
    }
    
}
