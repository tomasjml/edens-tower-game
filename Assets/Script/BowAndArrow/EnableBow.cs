using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBow : MonoBehaviour
{
    // Start is called before the first frame update
    private bool allEnemiesDied;
    public GameObject Enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allEnemiesDied=true;
        foreach (Transform child in Enemies.transform){
            if(child.gameObject.activeSelf==true){
                allEnemiesDied=false;
            }
        }
        if(allEnemiesDied==true){
            gameObject.SetActive(false);
        }
    }
}
