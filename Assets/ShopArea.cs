using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopArea : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("UIController").GetComponent<UIController>().setShoping();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("UIController").GetComponent<UIController>().setShoping();
    }
}
