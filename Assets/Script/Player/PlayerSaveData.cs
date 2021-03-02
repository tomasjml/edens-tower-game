using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerStats
{
    public int vitality;
    public int strength;
    public int speed;
    public int luck;
    public int defense;
    public Vector2 position;
    public string sceneName;
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public void AddItemToInventory(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] += 1;
        } else
        {
            inventory.Add(item, 1);
        }
    }

    public void DeleteItemToInventory(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory.Remove(item);
        } else
        {
            Debug.LogError("Ïtem " + item.title + " not in Inventory");
        }
    }

  }
