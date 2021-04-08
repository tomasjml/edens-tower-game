using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivate : MonoBehaviour
{
    public GameObject player;

    public void activate()
    {
        player.GetComponent<PlayerControllerV2>().enableKeys(true);
    }

    public void deactivate()
    {
        player.GetComponent<PlayerControllerV2>().enableKeys(false);
    }
}
