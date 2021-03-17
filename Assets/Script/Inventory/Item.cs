using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public enum Type
    {
        // Types are:
        Currency,       // 0
        Quest,          // 1
        Weapon,         // 2
        Consumables     // 3

    }

    private const string ItemsRoute = "Sprites/Items/";
    public int id;
    public string title;
    public Type type;
    public string description;
    public Sprite icon;
    public ItemStats stats = new ItemStats();
    public Item(int id, string title, Type type, string description, ItemStats stats)
    {
        this.id = id;
        this.title = title;
        this.type = type;
        this.description = description;
        icon = Resources.Load<Sprite>(ItemsRoute + title);
        this.stats = stats;
    }

    public Item(Item item)
    {
        id = item.id;
        title = item.title;
        description = item.description;
        icon = Resources.Load<Sprite>(ItemsRoute + title);
        stats = item.stats;
    }
}
