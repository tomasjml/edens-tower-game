using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagement : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update

    private void Awake()
    {
        BuildItems();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItemByTitle(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildItems()
    {
        // 0: Currency
        // Types are:
        // 1: Quest
        // 2: Weapons
        // 3: Consumables
        items = new List<Item>
        {
            // All Items have Type
            //  Currency Items stats: Value
            new Item(0, "Magic Stone", "MagicWorld Currency",
            new Dictionary<string, int>
            {
                {"Value",  1},
                {"Type", 0 }
            }),
            // Quest items stats: 
            new Item(1, "Tiara", "Lisa's Tiara which fell up front of the Tower",
            new Dictionary<string, int>
            {
                {"Type", 1 }
            }),
            // Weapon Items stats: Attack, Value, Category and Evolution
            // Weapon Categories: Ranged = 2, Meele = 1
            new Item(2, "Basic Sword", "The Sword picked up in Front of the Tower",
            new Dictionary<string, int>
            {
                {"Value",  15},
                {"Type", 2 },
                {"Attact", 10 },
                {"Category", 1 },
                {"Evolution", 1 }
            }),
            new Item(2, "Basic Bow", "The Bow first sold in the Market",
            new Dictionary<string, int>
            {
                {"Value",  15},
                {"Type", 2 },
                {"Attact", 5 },
                {"Category", 1 },
                {"Evolution", 1 }
            }),
        };
    };
    }
}
