using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCorroutine : MonoBehaviour
{
    public GameObject NPC;
    public string coroutine_name;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerV2>().enableKeys(false);
            NPC.GetComponent<NPCcontroller>().StartCoroutine(coroutine_name);
        }
    }
}
