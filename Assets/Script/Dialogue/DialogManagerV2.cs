using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class DialogManagerV2 : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;
    public Text displayText2;

    Queue<string> sentences; // listado de string
    string activeSentence;
    public float typingString;
    AudioSource myAudio;
    public AudioClip speakSound;
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    public GameObject _Trigger;
    public GameObject[] TriggersDestroy;

    public PlayerControllerV2 _Player;
    public GameObject _bot;
    public GameObject NPC;
    public GameObject _InstructionPressE;
    public Transform _PositionPreesE;
    public Animator Chest;

    private bool onSite = false;

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

        foreach (string sentence in dialogue.sentenceList) //buscar todas las sentences de ese listado y asi una a una se añadan al queue.
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
                myAudio.PlayOneShot(speakSound);
            }
            else
            {
                displayText2.text += letter;
                myAudio.PlayOneShot(speakSound);
            }
            yield return new WaitForSeconds(typingString);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            onSite = true;
            dialoguePanel.SetActive(true);
            Chest.SetTrigger("Open");
            StartDialogue();
            _Player.enableKeys(false);
        }

    }


    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("NPC"))
        {
            onSite = false;
            dialoguePanel.SetActive(false);
            dialoguePanel2.SetActive(false);
            _Trigger.SetActive(false);

        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence && sentences.Count % 2 == 0 && onSite) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(KeyCode.E) && displayText2.text == activeSentence && !(sentences.Count % 2 == 0) && onSite) // display == active es comparando para saber si ya el efecto de typing termino
        {
            DisplayNextSentence();
        }

        if (sentences.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _bot.SetActive(true);
                Destroy(NPC);
                _Player.enableKeys(true);
                foreach (GameObject c in TriggersDestroy){
                    Destroy(c, 0);
                }
                Item coin = GameManager.instance.itemManagement.GetItemByTitle(ItemManagement.ItemAvailable.MagicStone);
                GameManager.instance.saveData.playerData.AddItemToInventory(coin, 30);
            }
        }
    }


}
