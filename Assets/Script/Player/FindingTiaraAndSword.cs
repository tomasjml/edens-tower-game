using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FindingTiaraAndSword : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tiara;
    private int veces;
    private PlayerControllerV2 playerMainScript;
    public Transform textPlayerBox;
    public Text dialogPlayerText;
    void Start()
    {
        playerMainScript=gameObject.GetComponent<PlayerControllerV2>();
        veces=0;
        textPlayerBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(veces==0 && transform.position.x>1.16 &&tiara.gameObject.activeSelf==true){   
            playerMainScript.enableKeys(false);
            textPlayerBox.gameObject.SetActive(true);
            dialogPlayerText.text="That's Lisa's Tiara! I'll give it to her when i rescue her. I need to find a weapon.";
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W) && veces==1){
            playerMainScript.enableKeys(true);
            textPlayerBox.gameObject.SetActive(false);
            dialogPlayerText.text="";
            
        }
    }
}
