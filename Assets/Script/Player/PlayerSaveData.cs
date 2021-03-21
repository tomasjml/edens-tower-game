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
    public Vector3 position;
    public string sceneName;
    public ItemInventory inventory = new ItemInventory();

    public void AddItemToInventory(Item item)
    {
        if (inventory.ContainsKey(item) && item.type != Item.Type.Weapon && item.type != Item.Type.Quest)
        {
            inventory[item] += 1;
        } else
        {
            inventory.Add(item, 1);
        }
    }

    public void AddItemToInventory(Item item, int quantity)
    {
        if (inventory.ContainsKey(item) && item.type != Item.Type.Weapon && item.type != Item.Type.Quest)
        {
            inventory[item] += quantity;
        }
        else
        {
            inventory.Add(item, quantity);
        }
    }

    public void RemoveItemToInventory(Item item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory.Remove(item);
        } else
        {
            Debug.LogError("�tem " + item.title + " not in Inventory");
        }
    }

    public void RemoveItemToInventory(Item item, int quantity)
    {
        int removal = inventory[item] - quantity;
        if (inventory.ContainsKey(item))
        {
            if(removal <= 0)
            {
                inventory.Remove(item);
            }
            else
            {
                inventory[item] -= quantity;
            }
        }
        else
        {
            Debug.LogError("�tem " + item.title + " not in Inventory");
        }
    }

    public int ItemQuantityInInventory(string title)
    {
        Item itemFound = GameManager.instance.itemManagement.GetItemByTitle(title);
        if (inventory.ContainsKey(itemFound))
        {
            return inventory[itemFound];
        }
        else
        {
            return 0;
        }
    }
}
