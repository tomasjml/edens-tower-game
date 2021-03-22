using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateKey : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject key;
    public GameObject wizard;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wizard.activeSelf==false){
            key.SetActive(true);
            if(player.transform.position.x>28.7){
                player.GetComponent<PlayerControllerV2>().enableKeys(false);
                if(Input.GetKeyDown(KeyCode.E)){
                    key.SetActive(false);
                    player.GetComponent<PlayerControllerV2>().enableKeys(true);
                    this.gameObject.SetActive(false);
                }
            }

        }else{
            key.SetActive(false);
            //Debug.Log("este objeto SI esta activo");
        }
        
    }
}
