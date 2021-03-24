using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInventory : UnitySerializedDictionary<Item, int> { };

[System.Serializable]
public class ItemStats : UnitySerializedDictionary<string, int> { };