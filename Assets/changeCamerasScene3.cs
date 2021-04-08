using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeCamerasScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activateBookCamera;
    public GameObject bookCamera;
    public GameObject playerCamera;
    Queue<string> sentences;
    public Dialogue dialogue;
    public Text displayText;
    public Text displayText2;
   // listado de string
    string activeSentence;
    public float typingString;
   
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    
    public GameObject _InstructionPressE;
    public Transform _PositionPreesE;

    private GameObject instantiatedObject;
    private int cant=0;
    public GameObject otherDialog;
    public GameObject book;
    public GameObject finishThis;
    void Start()
    {
        sentences = new Queue<string>();
    }
    void StartDialogue()
    {
        sentences.Clear(); //borra el listado para empezar desde 0.

        foreach( string sentence in dialogue.sentenceList) //buscar todas las sentences de ese listado y asi una a una se añadan al queue.
        {
            sentences.Enqueue(sentence); //toma la oración y la añade al queue para ser presentada.

        }
        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
         if (sentences.Count == 0)
        {
            dialoguePanel.SetActive(true);
            displayText.text = activeSentence;
            return;
        }
        else
        {
            if (sentences.Count % 2 == 0)
            {
                dialoguePanel2.SetActive(true);
                dialoguePanel.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText.text = activeSentence;
            }
            else
            {
                dialoguePanel.SetActive(true);
                dialoguePanel2.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText2.text = activeSentence;
            }
        }
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
        
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        if (sentences.Count % 2 == 1)
        {
            displayText.text = "";
        }
        else
        {
            displayText2.text = "";
        }

        foreach (char letter in sentence.ToCharArray()) // toCharArray rompe la sentence en caracter y asi podemos hacer la anim de escribir letter por letter
        {
            if (sentences.Count % 2 == 1)
            {
                displayText.text += letter;
                
            }
            else
            {
                displayText2.text += letter;
                
            }
            yield return new WaitForSeconds(typingString);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((activateBookCamera==null || activateBookCamera.activeSelf==false) &&finishThis.activeSelf==false){
            bookCamera.SetActive(true);
            playerCamera.SetActive(false);
            otherDialog.SetActive(false);
            book.SetActive(true);
        }
        if(finishThis.activeSelf){
            bookCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        if(bookCamera.activeSelf&& cant==0){
            dialoguePanel.SetActive(true);
            //dialoguePanel2.SetActive(true);
            StartDialogue();
           
            instantiatedObject = Instantiate(_InstructionPressE,_PositionPreesE.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
            cant++;
        }
        if(cant>0){
            Debug.Log("sentences count"+sentences.Count);
            if (sentences.Count!=1&&displayText.text == activeSentence && sentences.Count % 2 == 1 ) // display == active es comparando para saber si ya el efecto de typing termino
            {
                DisplayNextSentence();
            }
        if ( sentences.Count!=1&&displayText2.text == activeSentence && !(sentences.Count % 2 == 1) ) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
        }
        if(sentences.Count==1){
             if(Input.GetKeyDown(KeyCode.E))
                {
                     Debug.Log("Presione E para terminar.");
                    Destroy(instantiatedObject);
                    finishThis.SetActive(true);
                    activateBookCamera.SetActive(true);
                    dialoguePanel.SetActive(false);
                    instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
                }
        }
        
        }
    }
}
