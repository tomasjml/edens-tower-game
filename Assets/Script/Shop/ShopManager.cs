using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;

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


    private int gems;
    public Text gemText;

    // Start is called before the first frame update
    void Awake()
    {
        gemText.text = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        GameObject ButtonRef = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (ButtonRef.GetComponentInChildren<Text>().enabled)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle(ButtonRef.GetComponentInChildren<Text>().text);

            gems = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
            int price = GameManager.instance.itemManagement.GetItemByTitle(item.title).stats["Value"];
            if (gems >= price)
            {
                GameManager.instance.MarketBuyItem(item.title, 1);
                Debug.Log(GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone"));
                gemText.text = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
                gems = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
                updateBow();
                updateSword();
            }
        }  
    }

    public void Sell()
    {
        GameObject ButtonRef = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (ButtonRef.GetComponentInChildren<Text>().enabled)
        {
            Item item = GameManager.instance.itemManagement.GetItemByTitle(ButtonRef.GetComponentInChildren<Text>().text);
            gems = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
            GameManager.instance.MarketSellItem(item.title, 1);
            gemText.text = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
            gems = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
            updateBow();
            updateSword();
        }
    }

    public void DisableButton()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Button").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonRef.SetActive(false);
    }

    public void ViewShop()
    {
        if (shopPanel.activeSelf)
        {
            CloseShop();
        }
        else
        {
            OpenShop();
        }
    }



    public void CloseShop()
    {
        GameObject.Find("UIController").GetComponent<UIController>().setHud();
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
    }

    private void Start()
    {
        updateBow();
        updateSword();
    }
    public void updateBow()
    {
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

    public void updateSword()
    {
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
    }

 }
