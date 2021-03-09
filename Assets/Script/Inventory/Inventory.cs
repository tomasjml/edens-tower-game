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

    // Start is called before the first frame update
    void Start()
    {
        inventoryChilds.SetActive(false);
        Button closeButton = inventoryChilds.transform.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(() =>
        {
            CloseInventory();
        });
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

        itemStory1.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemStory2.transform.Find("Image").GetComponent<Image>().enabled = false;
        itemStory3.transform.Find("Image").GetComponent<Image>().enabled = false;
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
