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
    //public GameObject dialoguePanel2;
    //public GameObject _Trigger;
    //public GameObject[] TriggersDestroy;

    //public PlayerControllerV2 _Player;
    
    //public GameObject _InstructionPressE;
    //public Transform _PositionPreesE;
    //public Animator Chest;
    private int cant=0;
    private bool onSite = false;
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
        }
        else
        {
            //if (sentences.Count % 2 == 0)
            //{
                //dialoguePanel2.SetActive(false);
                dialoguePanel.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText.text = activeSentence;
           // }
            /*else
            {
                dialoguePanel.SetActive(false);
                dialoguePanel2.SetActive(true);
                activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
                displayText2.text = activeSentence;
            }*/
        }
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        //if (sentences.Count % 2 == 0)
        //{
            displayText.text = "";
        //}
        /*else
        {
            displayText2.text = "";
        }*/

        foreach (char letter in sentence.ToCharArray()) // toCharArray rompe la sentence en caracter y asi podemos hacer la anim de escribir letter por letter
        {
            //if (sentences.Count % 2 == 0)
            //{
                displayText.text += letter;
                
            //}
            //else
            //{
              //  displayText2.text += letter;
                
            //}
            yield return new WaitForSeconds(typingString);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("camStory"))
        {
            onSite = true;
            dialoguePanel.SetActive(true);
           // Debug.Log("entro al trigger");
            //Chest.SetTrigger("Open");
            StartDialogue();
            //_Player.enableKeys(false);
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
