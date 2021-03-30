using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth playerHealthScript;
    private int currentHealth;
    private int originalHealth;
    
    void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        currentHealth=playerHealthScript.getCurrentHealth();
       //originalHealth=playerHealthScript.getOriginalHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
