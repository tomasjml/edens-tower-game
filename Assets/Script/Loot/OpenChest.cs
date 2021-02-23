using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Transform _PositionPressE;
    public GameObject _InstructionPressE;

    Animator animator;

    private GameObject instantiatedObject;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Ha entrado");
            if(animator.GetBool("OpenChest") == false)
            instantiatedObject = Instantiate(_InstructionPressE,_PositionPressE.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("OpenChest");
                instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
        }
    }

}