using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerControllerV2 playerController;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo){
        Debug.Log("Entro a un collider");
        if(collisionInfo.collider.tag=="Die"){
            Debug.Log("Entro");
            // FindObjectOfType<GameManager>().endGame();
            GameManager.instance.EndGame();
        }
    }
}
