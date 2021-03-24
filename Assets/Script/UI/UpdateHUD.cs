using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHUD : MonoBehaviour
{
    private int stonesAmount = 0;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAA");
        stonesAmount = GameManager.instance.saveData.playerData.ItemQuantityInInventory("Magic Stone");
        _text.SetText(stonesAmount.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
