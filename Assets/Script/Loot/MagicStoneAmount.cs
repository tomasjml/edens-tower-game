using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneAmount : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("FX Coin")]
    private AudioSource fxCoin;
    public AudioClip coin;
    public GameObject _Magic_Stone;

    private void Start()
    {
        fxCoin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            fxCoin.PlayOneShot(coin);
            Destroy(gameObject, 0.3f);
            Item stone = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MagicStone);
            
            switch (GameManager.instance.saveData.difficulty)
            {
                case SaveData.Difficulty.Easy:
                    GameManager.instance.saveData.playerData.AddPoints(5);
                    GameManager.instance.saveData.playerData.AddItemToInventory(stone, Random.Range(5, 20));
                    break;
                case SaveData.Difficulty.Normal:
                    GameManager.instance.saveData.playerData.AddPoints(10);
                    GameManager.instance.saveData.playerData.AddItemToInventory(stone, Random.Range(5, 20));
                    break;
                case SaveData.Difficulty.Hard:
                    GameManager.instance.saveData.playerData.AddPoints(15);
                    GameManager.instance.saveData.playerData.AddItemToInventory(stone, Random.Range(5, 20));
                    break;
                case SaveData.Difficulty.Hell:
                    GameManager.instance.saveData.playerData.AddPoints(20);
                    GameManager.instance.saveData.playerData.AddItemToInventory(stone, Random.Range(5, 20));
                    break;
            }
            
        }
    }


    

    
}
