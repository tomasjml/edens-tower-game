using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _a;
    private void Awake()
    {
        _a = GetComponentInParent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject NPC = GameObject.Find("NPC");
            NPC.GetComponent<NPCSimple>().enabled = true;
            other.GetComponent<PlayerControllerV2>().enableKeys(false);
            _a.SetBool("Idle", true);
            Invoke("update", 10221212);
        }

    }
    private void update()
    {
        GameObject.Find("NPC").GetComponent<NPCSimple>().finished = true;
    }
}
