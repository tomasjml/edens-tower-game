using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryChilds;

    // Start is called before the first frame update
    void Start()
    {
        inventoryChilds.SetActive(false);
        Button button = (Button) inventoryChilds.GetComponent("Close Button");
        Debug.Log(button.name);
        button.onClick.AddListener(() =>
        {
            CloseInventory();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSlots()
    {
        GameObject consumableItems = GameObject.Find("Consumables");
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
        Debug.Log("Inventory showing");
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
