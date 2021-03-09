using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryChilds;

    // Buttons
    // Consumables
    public Button itemConsumables1;
    public Button itemConsumables2;
    public Button itemConsumables3;

    // Story
    public Button itemStory1;
    public Button itemStory2;
    public Button itemStory3;

    // Weapons
    public Button itemWeapon1;
    public Button itemWeapon2;
    public Button itemWeapon3;

    // Text
    public Text textCurrency;

    // Start is called before the first frame update
    void Start()
    {
        inventoryChilds.SetActive(false);
        Button closeButton = inventoryChilds.transform.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(() =>
        {
            CloseInventory();
        });
        GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle("Magic Stone"), 100);
        GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle("Tiara"), 1);
        GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle("Basic Sword"), 1);
        GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle("Basic Potion"), 1);

        UpdateSlots();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSlots()
    {
        itemConsumables1.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemConsumables2.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemConsumables3.transform.Find("Image").GetComponent<Image>().enabled = false;

        itemWeapon1.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemWeapon2.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemWeapon3.transform.Find("Image").GetComponent<Image>().enabled = false;

        if(GameManager.instance.saveData.playerData.ItemQuantityInInventory("Tiara") > 0)
        {
            Item tiara = GameManager.instance.itemManagement.GetItemByTitle("Tiara");
            if (tiara.icon != null)
            {
                Debug.Log("Tiara Sprite is present");
            }
            else
            {
                Debug.LogError("Tiara Sprite is not present!");
            }
            itemStory1.transform.Find("Image").GetComponent<Image>().sprite = tiara.icon;
            itemStory1.transform.Find("Text").GetComponent<Text>().enabled = false;
        }
        else
        {
            itemStory1.transform.Find("Image").GetComponent<Image>().enabled = false;
        }
        itemStory2.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemStory3.transform.Find("Image").GetComponent<Image>().enabled = false;

        textCurrency.text = "Currency: " + GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
    }

    public void ViewInventory()
    {
        if (inventoryChilds.activeSelf)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
        UpdateSlots();
    }

    public void CloseInventory()
    {
        inventoryChilds.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
    }

    public void OpenInventory()
    {
        inventoryChilds.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
    }
}
