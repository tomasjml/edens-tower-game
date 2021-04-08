using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManagement : MonoBehaviour
{

    public enum ItemAvailable
    {
        MagicStone,
        Tiara,
        BasicSword,
        BasicBow,
        BasicPotion
    }

    public List<Item> items = new List<Item>();
    public List<Item> itemsMarket = new List<Item>();
    // Start is called before the first frame update

    private void Awake()
    {
        BuildItems();
        BuildMarket();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItemByTitle(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    public Item GetItemByTitle(ItemAvailable itemAvailable)
    {
        string itemName = "";
        switch (itemAvailable)
        {
            case ItemAvailable.MagicStone:
                itemName = "Magic Stone";
                break;
            case ItemAvailable.Tiara:
                itemName = "Tiara";
                break;
            case ItemAvailable.BasicSword:
                itemName = "Basic Sword";
                break;
            case ItemAvailable.BasicBow:
                itemName = "Basic Bow";
                break;
            case ItemAvailable.BasicPotion:
                itemName = "Basic Potion";
                break;
            default:
                break;
        }
        return items.Find(item => item.title == itemName);
    }

    public List<string> GetTitlesOfItems()
    {
        return items.Select(item => item.title).ToList();
    }

    public void BuildItems()
    {
        items = new List<Item>
        {
            // All Items have Type
            // Currency Items stats: Value
            new Item(0, "Magic Stone",Item.Type.Currency, "MagicWorld Currency",
            new ItemStats
            {
                {"Value",  1}
            }),
            // Quest items stats: 
            new Item(1, "Tiara", Item.Type.Quest, "Lisa's Tiara which fell up front of the Tower",
            new ItemStats
            {
                {"Value", - 1 }
            }),
            // Weapon Items stats: Attack, Value, Category and Evolution
            // Weapon Categories: Ranged = 2, Meele = 1
            new Item(2, "Basic Sword", Item.Type.Weapon, "The Sword picked up in Front of the Tower",
            new ItemStats
            {
                {"Value",  15},
                {"Attact", 10 },
                {"Category", 1 },
                {"Evolution", 1 }
            }),
            new Item(3, "Basic Bow", Item.Type.Weapon, "The Bow first sold in the Market",
            new ItemStats
            {
                {"Value",  15},
                {"Attact", 5 },
                {"Category", 2 },
                {"Evolution", 1 }
            }),
            // Consumables items stats: 
            // Type: Category = 
            new Item(4, "Basic Potion", Item.Type.Consumables, "The \"Go to \" option for Cheap recovery of 1 Heart",
            new ItemStats
            {
                {"Value",  30},
                {"Recovery", 4}
            })
        };
    }

    public void BuildMarket()
    {
        itemsMarket = new List<Item>
        {
            GetItemByTitle(ItemAvailable.BasicPotion),
            GetItemByTitle(ItemAvailable.BasicBow)

        };
    }
}
