using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHP : MonoBehaviour
{
    public GameObject _Player;

    int totalHP;
    private void Start()
    {
        //totalHP = GameManager.instance.saveData.playerData.vitality;
        totalHP = 20;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(totalHP);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            totalHP -= collision.GetComponent<PlayerHealth>().getCurrentHealth();
            collision.GetComponent<PlayerHealth>().setHealth(totalHP);
            Destroy(gameObject);
        }
    }
}
