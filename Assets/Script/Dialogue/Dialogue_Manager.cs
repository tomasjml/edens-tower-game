using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;
    Queue<string> sentences; // listado de string
    string activeSentence;
    public float typingString;
    AudioSource myAudio;
    public AudioClip speakSound;
    public GameObject dialoguePanel;
    public GameObject _Trigger;
    public PlayerControllerV2 _Player;
    public GameObject _InstructionPressE;
    public Transform _PositionPreesE;

    private GameObject instantiatedObject;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
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
        if(sentences.Count == 0)
        {
            displayText.text = activeSentence;
            return;
        }
        activeSentence = sentences.Dequeue(); // saca la oracion del listado y la pasa al activeSentence
        
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
        
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach( char letter in sentence.ToCharArray()) // toCharArray rompe la sentence en caracter y asi podemos hacer la anim de escribir letter por letter
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingString);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag("Player") )
        {
            
            dialoguePanel.SetActive(true);
            StartDialogue();
            _Player.enableKeys(false);
            instantiatedObject = Instantiate(_InstructionPressE,_PositionPreesE.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
            
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if( other.CompareTag("Player") )
        {
            if(Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence) // display == active es comparando para saber si ya el efecto de typing termino
            {
                DisplayNextSentence();  
            }


            if(sentences.Count == 0)
            {
                Debug.Log("Presione E para terminar.");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    _Player.enableKeys(true);
                    Destroy(instantiatedObject);
                    Destroy(_Trigger,0);
                    instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
                }
                 
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if( other.CompareTag("Player") )
        {
            dialoguePanel.SetActive(false);    
            _Trigger.SetActive(false);
            
        }
    }

   
}
