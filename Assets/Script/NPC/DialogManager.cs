using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;
    public Text dialogText;
    public Text dialogPlayerText;
    public Transform dialoguePlayer;
    public Transform dialogueNPC;
    private SpriteRenderer orderLayerTextboxSprite;
    public bool dialogueFinished;
    void Awake(){
        orderLayerTextboxSprite=dialoguePlayer.gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        sentences=new Queue<string>();
        dialogText.gameObject.SetActive(false);
        dialogPlayerText.gameObject.SetActive(false);
        dialogueFinished=false;
    }
    public void StartDialog(ObjectDialog dialogue){
        //Debug.Log("start dialogue");
        sentences.Clear();
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
            
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        dialogText.gameObject.SetActive(true);
        if(sentences.Count==0 && dialogueFinished==false){
            EndDialogue();

            return;
        }
         
        if(sentences.Count==8){
            orderLayerTextboxSprite.sortingOrder=2;
            dialogPlayerText.gameObject.SetActive(true);
        }
        
        if(sentences.Count==7|| sentences.Count==8 || sentences.Count==5){ 
            string sentence=sentences.Dequeue();   
            dialoguePlayer.gameObject.SetActive(true); 
            dialogText.text="";
            dialogueNPC.gameObject.SetActive(false);
             dialogPlayerText.text=sentence;
            
        }
        else{   
            string sentence=sentences.Dequeue();
            dialoguePlayer.gameObject.SetActive(false); 
            dialogPlayerText.text="";
            dialogueNPC.gameObject.SetActive(true);
            dialogText.text=sentence;
        }

    }
    void EndDialogue(){
        Debug.Log("end of conversation");
        dialogPlayerText.text="";
        dialogText.text="";
        dialoguePlayer.gameObject.SetActive(false); 
        dialogueNPC.gameObject.SetActive(false);
        dialogueFinished=true;
    }
    public bool isDialogueialogueFinished(){
        return dialogueFinished;
    }
    public void setDialogueFinished(bool setDialogue){
        dialogueFinished=setDialogue;
    }
    
}
