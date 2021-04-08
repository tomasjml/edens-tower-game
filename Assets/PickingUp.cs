using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    public GameObject ob;
    public GameObject _player;
    private Animator _player_animator;


    private void Awake()
    {
        _player_animator = _player.GetComponent<Animator>();
    }
    public void addItem()
    {
        Debug.Log("TOY AQUI MIJO");
        if (ob.CompareTag("Tiara"))
        {
            Destroy(ob);
            _player_animator.SetTrigger("pickUpTiara");
            GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.Tiara));

        }
        if (ob.CompareTag("Sword"))
        {
            Destroy(ob);
            _player_animator.SetTrigger("pickUpSword");
            GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.BasicSword));
        }
    }
    
}
