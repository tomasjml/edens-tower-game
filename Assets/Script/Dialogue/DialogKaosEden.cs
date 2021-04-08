using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DialogKaosEden : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;
    public Text displayText2;

    Queue<string> sentences; // listado de string
    string activeSentence;
    public float typingString;
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    private int cant=0;
    private Animator _animator;
    public GameObject Eden;
    public  GameObject firstPartFinished;
    private int cantTrigger=0;
    

    private bool onSite = false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _animator=Eden.gameObject.GetComponent<Animator>();
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

        
        if(sentences.Count!=0)
        {
            if (sentences.Count % 2 != 0)
            {
                dialoguePanel2.SetActive(false);
                dialoguePanel.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText.text = activeSentence;
            }
            else
            {
                dialoguePanel.SetActive(false);
                dialoguePanel2.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText2.text = activeSentence;
            }
        }
        else
        {
            dialoguePanel.SetActive(true);
            displayText.text = activeSentence;
            firstPartFinished.SetActive(true);
            return;
        }

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        if (sentences.Count % 2 == 0)
        {
            displayText.text = "";
        }
        else
        {
            displayText2.text = "";
        }

        foreach (char letter in sentence.ToCharArray()) // toCharArray rompe la sentence en caracter y asi podemos hacer la anim de escribir letter por letter
        {
            if (sentences.Count % 2 == 0)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kaos")){
            onSite=true;
            
           
           if(cantTrigger==0){
               dialoguePanel.SetActive(true);
               StartDialogue();
               cantTrigger++;
           }
            
        }
        

    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && sentences.Count != 0 && onSite) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
            if(sentences.Count==2){
                _animator.SetBool("almostDead",true);
            }
            else if(sentences.Count==1){
                _animator.SetBool("dead",true);
            }
        }
        
        if (sentences.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialoguePanel2.SetActive(false);
                dialoguePanel.SetActive(false);
                if(onSite==true){
                    firstPartFinished.SetActive(true);
                }
                
            }
        }
    }
}
