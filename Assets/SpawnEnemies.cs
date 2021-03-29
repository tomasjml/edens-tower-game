using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] _Enemies;
    Transform[] padre;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        padre = this.transform.GetComponentsInChildren<Transform>();
        if(padre != null)
        {
            
        }
    }

    void Enemies()
    {
        Instantiate(_Enemies[Random.Range(0, 4)], this.transform.position, Quaternion.identity);
        
        
    }
    
}
