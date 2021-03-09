using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    private int gems;
    private Image image;
    public Text gemText;
    public int skill_Price;

    // Start is called before the first frame update
    void Start()
    {
        gemText.text = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Button").GetComponent<EventSystem>().currentSelectedGameObject;
        Item item = GameManager.instance.itemManagement.GetItemByTitle(ButtonRef.name);
        int price = GameManager.instance.saveData.playerData.ItemQuantityInInventory(ButtonRef.name);
        if (gems >= price)
        {
            GameManager.instance.MarketBuyItem(ButtonRef.name, 1);

            gemText.text = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone").ToString();
            gems = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
        }
          
    }
    
    public void DisableButton()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Button").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonRef.SetActive(false);
    }

    public void SkillUpVitatily()
    {
        if (gems >= skill_Price)
        {
            GameManager.instance.saveData.playerData.vitality += 1;
        }
    }
    public void SkillDownVitality()
    {
        int skill_Quantity = GameManager.instance.saveData.playerData.vitality;
        if(skill_Quantity > 0)
        {
            GameManager.instance.saveData.playerData.vitality -= 1;
        }
    }

    public void SkillUpStrength()
    {
        if (gems >= skill_Price)
        {
            GameManager.instance.saveData.playerData.strength += 1;
        }
    }
    public void SkillDownStrength()
    {
        int skill_Quantity = GameManager.instance.saveData.playerData.vitality;
        if (skill_Quantity > 0)
        {
            GameManager.instance.saveData.playerData.strength -= 1;
        }
    }
    public void SkillUpSpeed()
    {
        if (gems >= skill_Price)
        {
            GameManager.instance.saveData.playerData.speed += 1;
        }
    }
    public void SkillDownSpeed()
    {
        int skill_Quantity = GameManager.instance.saveData.playerData.vitality;
        if (skill_Quantity > 0)
        {
            GameManager.instance.saveData.playerData.speed -= 1;
        }
    }

}
