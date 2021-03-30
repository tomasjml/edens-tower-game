using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ShopManager : MonoBehaviour
{
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
        }
    }

    public void DisableButton()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Button").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonRef.SetActive(false);
    }

    public void CloseShop()
    {
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;
    }

    public void OpenShop()
    {
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
    }

}
