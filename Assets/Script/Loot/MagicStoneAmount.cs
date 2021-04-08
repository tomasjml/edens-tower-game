using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagicStoneAmount : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Magic_Stone;

    Unity.Mathematics.Random r = new Unity.Mathematics.Random();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(_Magic_Stone);
            Item stone = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MagicStone);
            GameManager.instance.saveData.playerData.AddItemToInventory(stone,5);
            switch (GameManager.instance.saveData.difficulty)
            {
                case SaveData.Difficulty.Easy:
                    GameManager.instance.saveData.playerData.AddPoints(5);
                    break;
                case SaveData.Difficulty.Normal:
                    GameManager.instance.saveData.playerData.AddPoints(10);
                    break;
                case SaveData.Difficulty.Hard:
                    GameManager.instance.saveData.playerData.AddPoints(15);
                    break;
                case SaveData.Difficulty.Hell:
                    GameManager.instance.saveData.playerData.AddPoints(20);
                    break;
            }
        }
    }

    private int Ran2m()
    {
        int random = r.NextInt(15);
        return random;
    }
}
