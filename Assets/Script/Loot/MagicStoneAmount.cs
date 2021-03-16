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
        }
    }

    private int Ran2m()
    {
        int random = r.NextInt(15);
        return random;
    }
}
