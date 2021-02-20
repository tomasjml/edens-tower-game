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
    private SpriteRenderer orderLayerTextboxSprite;
    void Awake(){
        orderLayerTextboxSprite=dialoguePlayer.gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        sentences=new Queue<string>();
        dialogText.gameObject.SetActive(false);
        dialogPlayerText.gameObject.SetActive(false);
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
        if(sentences.Count==0){
            EndDialogue();
            return;
        }
         
        if(sentences.Count==8){
            orderLayerTextboxSprite.sortingOrder=2;
            dialogPlayerText.gameObject.SetActive(true);
        }
        
        if(sentences.Count==7|| sentences.Count==8 || sentences.Count==5){ 
            string sentence=sentences.Dequeue();    
            dialogPlayerText.text=sentence;
            Debug.Log(sentence);
        }
        else{   
            string sentence=sentences.Dequeue();
            dialogText.text=sentence;}

    }
    void EndDialogue(){
        Debug.Log("end of conversation");
    }
    
}
