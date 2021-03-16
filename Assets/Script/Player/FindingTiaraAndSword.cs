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
    public Transform sword;
    
    public Transform textPlayerBoxSword;
    public Text dialogPlayerTextSword;
    private Animator _animation;
    
    void Start()
    {
        playerMainScript=gameObject.GetComponent<PlayerControllerV2>();
        _animation=GetComponent<Animator>();
        veces=0;
        textPlayerBox.gameObject.SetActive(false);
        textPlayerBoxSword.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(veces==0 && transform.position.x>1.093 &&tiara.gameObject.activeSelf==true){   
            playerMainScript.enableKeys(false);
            textPlayerBox.gameObject.SetActive(true);
            dialogPlayerText.text="That's Lisa's Tiara! I'll give it to her when i rescue her. I need to find a weapon.";
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W) && veces==1){
            playerMainScript.enableKeys(true);
            textPlayerBox.gameObject.SetActive(false);
            dialogPlayerText.text="";
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W) && veces==2){
            
            tiara.gameObject.SetActive(false);
             _animation.SetTrigger("pickUpTiara");;
            GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.Tiara));
        }
        if(veces==2 && transform.position.x>1.44 &&sword.gameObject.activeSelf==true){   
            playerMainScript.enableKeys(false);
            textPlayerBoxSword.gameObject.SetActive(true);
            dialogPlayerTextSword.text="This sword is the weapon i need!";
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W) && veces==3){  
            playerMainScript.enableKeys(true);
            textPlayerBoxSword.gameObject.SetActive(false);
            dialogPlayerTextSword.text="";
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W) && veces==4){
            sword.gameObject.SetActive(false);
            _animation.SetTrigger("pickUpSword");
            GameManager.instance.saveData.playerData.AddItemToInventory(GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.BasicSword));
        }
    }
}
