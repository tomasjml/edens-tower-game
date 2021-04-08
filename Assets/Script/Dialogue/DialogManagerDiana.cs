using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogManagerDiana : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;
    //public Text displayText2;

    Queue<string> sentences; // listado de string
    string activeSentence;
    public float typingString;
    
    public GameObject dialoguePanel;
   
    private int cant=0;
    
    public GameObject startEdenScene;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    void StartDialogue()
    {
        sentences.Clear(); //borra el listado para empezar desde 0.

        foreach (string sentence in dialogue.sentenceList) //buscar todas las sentences de ese listado y asi una a una se a�adan al queue.
        {
            sentences.Enqueue(sentence); //toma la oraci�n y la a�ade al queue para ser presentada.

        }
        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            dialoguePanel.SetActive(true);
            displayText.text = activeSentence;
            startEdenScene.SetActive(true);
            return;
        }else{
            
            dialoguePanel.SetActive(true);
            activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
            displayText.text = activeSentence;
           
        }
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        

        foreach (char letter in sentence.ToCharArray()) // toCharArray rompe la sentence en caracter y asi podemos hacer la anim de escribir letter por letter
        {
            displayText.text += letter;
                
            
            yield return new WaitForSeconds(typingString);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("camStory"))
        {
            
            dialoguePanel.SetActive(true);
           
            StartDialogue();
            
        }

    }


    private void Update()
    {

        if (cant==0 && displayText.text == activeSentence ) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
            cant++;
        }
        /*if (Input.GetKeyDown(KeyCode.E) && displayText2.text == activeSentence && !(sentences.Count % 2 == 0) && onSite) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
        }*/

        if (sentences.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                dialoguePanel.SetActive(false);
                
                
            }
        }
    }
}
