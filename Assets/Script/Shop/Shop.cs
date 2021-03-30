using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Button itemWeapon1;
    public Button itemWeapon2;
    public Button itemWeapon3;
    public Button itemWeapon4;

    public Button itemSell1;
    public Button itemSell2;
    public Button itemSell3;
    public Button itemSell4;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Bow") ==  0)
        {
            Item basicSword = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.BasicBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = basicSword.icon;
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = false;

        }
        else
        {
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
