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
                damage = GameManager.instance.saveData.playerData.vitality - 4;
                break;
        }

        if(!GameManager.instance)
        {
            damage = 1;
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
                    damage = 2;
                    break;
                case "Lava":
                    damage = 2;
                    break;
                case "Escombro":
                    damage = 4;
                    break;
                
                
            }
            Debug.Log("Se dio");
            collision.gameObject.SendMessageUpwards("AddDamage", damage);
            HeartVisual.HSystemStatic.Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Yunke":
                    damage = 2;
                    break;
                case "Lava":
                    damage = 2;
                    break;
                case "Escombro":
                    damage = 4;
                    break;
                case "MegaSkeleton":
                    damage = 4;
                    break;
                case "Skeleton":
                    damage = 2;
                    break;


            }
            Debug.Log("Se dio");
            collision.gameObject.SendMessageUpwards("AddDamage", damage);
            HeartVisual.HSystemStatic.Damage(damage);
        }
    }
}
