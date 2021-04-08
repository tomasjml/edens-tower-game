using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameObject canvas;
    public GameObject[] UIComponents;
    private static bool isShoping = false;

    public void setShoping(bool cond)
    {
        isShoping = cond;
    }


    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Pause");
    }

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(GameManager.instance.saveData.playerData.ItemQuantityInInventory(GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.Tiara).title));
            if (canvas.GetComponent<Inventory>().enabled)
            {
                
                SetInterface("InventoryUI");
                Inventory inventory = (Inventory)canvas.GetComponent(typeof(Inventory));
                inventory.ViewInventory();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.GetComponent<PauseMenu>().enabled)
            {
                SetInterface("PauseUI");
                PauseMenu pause = (PauseMenu)canvas.GetComponent(typeof(PauseMenu));
                pause.ViewPause();
            }
        }
        if(Input.GetKeyDown(KeyCode.T) && isShoping)
        {
            SetInterface("ShopUI");
            ShopManager shop = (ShopManager)canvas.GetComponent(typeof(ShopManager));
            shop.ViewShop();
        }


    }

    public void setHud()
    {
        SetInterface("HUD");
    }

    private void SetInterface(string Active)
    {
        if(Active != "HUD")
        {
            foreach (GameObject UI in UIComponents)
            {
                if (!UI.CompareTag(Active))
                {
                    UI.SetActive(false);
                }
            }
        }
        else
        {
            foreach (GameObject UI in UIComponents)
            {
                if (!UI.CompareTag(Active) && !UI.CompareTag("DialogUI"))
                {
                    UI.SetActive(false);
                }
                if(UI.CompareTag(Active) || UI.CompareTag("DialogUI"))
                {
                    UI.SetActive(true);
                }
            }
            

        }


    }


}
