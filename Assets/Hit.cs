using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    int damage = 1;

    private void Awake()
    {
        switch (GameManager.instance.saveData.difficulty)
        {
            case SaveData.Difficulty.Easy:
                damage = 1;
                break;
            case SaveData.Difficulty.Normal:
                damage = 2;
                break;
            case SaveData.Difficulty.Hard:
                damage = 4;
                break;
            case SaveData.Difficulty.Hell:
                damage = GameManager.instance.saveData.playerData.vitality - 2;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Se esta dando");
        if (collision.gameObject.CompareTag("Player"))
        {
            switch(gameObject.tag)
            {
                case "Yunke":
                    damage += 1;
                    break;
            }
            Debug.Log("Se dio");
            collision.gameObject.SendMessageUpwards("AddDamage", damage);
        }
    }
}
