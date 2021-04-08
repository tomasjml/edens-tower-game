using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Button itemWeapon1;
    public Button itemWeapon2;
    public Text itemWeapon1Price;
    public Text itemWeapon2Price;

    public Button itemSell1;
    public Button itemSell2;
    public Button itemSell3;
    public Text itemSell1Price;
    public Text itemSell2Price;
    public Text itemSell3Price;

    // Start is called before the first frame update
    void Start()
    {
        //Start of the bow slot 
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Bow") < 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.BasicBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Basic Bow";
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Bow") >= 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.KillerBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Killer Bow";
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Killer Bow") >= 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MiracleBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Miracle Bow";
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else
        {
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemWeapon1Price.enabled = false;

        }

        //Start of the Sword Slot
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Sword") >= 1)
        {
            Item Sword = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.KillerSword);
            itemWeapon2.transform.Find("Image").GetComponent<Image>().sprite = Sword.icon;
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().text = "Killer Sword";
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon2Price.text = Sword.stats["Value"].ToString() + "g";
            itemWeapon2Price.enabled = true;

        }
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Killer Sword") >= 1)
        {
            Item Sword = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MiracleSword);
            itemWeapon2.transform.Find("Image").GetComponent<Image>().sprite = Sword.icon;
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().text = "Miracle Sword";
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon2Price.text = Sword.stats["Value"].ToString() + "g";
            itemWeapon2Price.enabled = true;

        }
        else
        {
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemWeapon2Price.enabled = false;
        }


        //Start of the sell slots
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Potion") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Basic Potion");
            itemSell1.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell1Price.text = item.stats["Value"].ToString() + "g";
            itemSell1Price.enabled = true;
        }
        else
        {
            itemSell1.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell1.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell1Price.enabled = false;
        }


        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Huge Potion") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Huge Potion");
            itemSell2.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell2Price.text = item.stats["Value"].ToString() + "g";
            itemSell2Price.enabled = true;

        }
        else
        {
            itemSell2.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell2.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell2Price.enabled = false;
        }

        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Blasting Stone") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Blasting Stone");
            itemSell3.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell3.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell1.transform.Find("Text").GetComponent<Text>().text = item.stats["Value"].ToString() + "g";
            itemSell3.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell3Price.text = item.stats["Value"].ToString() + "g";
            itemSell3Price.enabled = true;

        }
        else
        {
            itemSell3.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell3.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell3Price.enabled = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        //Start of the bow slot 
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Bow") < 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.BasicBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Basic Bow";
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Bow") >= 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.KillerBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Killer Bow";
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Killer Bow") >= 1)
        {
            Item Bow = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MiracleBow);
            itemWeapon1.transform.Find("Image").GetComponent<Image>().sprite = Bow.icon;
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().text = "Miracle Bow";
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon1Price.text = Bow.stats["Value"].ToString() + "g";
            itemWeapon1Price.enabled = true;

        }
        else
        {
            itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemWeapon1.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemWeapon1Price.enabled = false;

        }

        //Start of the Sword Slot
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Sword") >= 1)
        {
            Item Sword = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.KillerSword);
            itemWeapon2.transform.Find("Image").GetComponent<Image>().sprite = Sword.icon;
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().text = "Killer Sword";
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon2Price.text = Sword.stats["Value"].ToString() + "g";
            itemWeapon2Price.enabled = true;

        }
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Killer Sword") >= 1)
        {
            Item Sword = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MiracleSword);
            itemWeapon2.transform.Find("Image").GetComponent<Image>().sprite = Sword.icon;
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().text = "Miracle Sword";
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemWeapon2Price.text = Sword.stats["Value"].ToString() + "g";
            itemWeapon2Price.enabled = true;

        }
        else
        {
            itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemWeapon2.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemWeapon2Price.enabled = false;
        }


        //Start of the sell slots
        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Basic Potion") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Basic Potion");
            itemSell1.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell1.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell1.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell1Price.text = item.stats["Value"].ToString() + "g";
            itemSell1Price.enabled = true;
        }
        else
        {
            itemSell1.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell1.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell1Price.enabled = false;
        }


        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Huge Potion") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Huge Potion");
            itemSell2.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell2.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell2.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell2Price.text = item.stats["Value"].ToString() + "g";
            itemSell2Price.enabled = true;

        }
        else
        {
            itemSell2.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell2.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell2Price.enabled = false;
        }

        if (GameManager.instance.saveData.playerData.ItemQuantityInInventory("Blasting Stone") > 0)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle("Blasting Stone");
            itemSell3.transform.Find("Image").GetComponent<Image>().sprite = item.icon;
            itemSell3.transform.Find("Image").GetComponent<Image>().enabled = true;
            itemSell1.transform.Find("Text").GetComponent<Text>().text = item.stats["Value"].ToString() + "g";
            itemSell3.transform.Find("Text").GetComponent<Text>().enabled = true;
            itemSell3Price.text = item.stats["Value"].ToString() + "g";
            itemSell3Price.enabled = true;

        }
        else
        {
            itemSell3.transform.Find("Image").GetComponent<Image>().enabled = false;
            itemSell3.transform.Find("Text").GetComponent<Text>().enabled = false;
            itemSell3Price.enabled = false;

        }
    }
}
