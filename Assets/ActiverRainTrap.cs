using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverRainTrap : MonoBehaviour
{
    public bool rainON = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rainON = true;
            Debug.Log(rainON);
        }
    }

    public bool time2Rain()
    {
        return rainON;
    }
}
