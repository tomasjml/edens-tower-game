using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DialogManagerV4 : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;
    public GameObject instruction;
    public Transform position;

    private GameObject instanciated;

    Queue<string> sentences;
    string activeSentence;
    public float typingString;
    public GameObject dialoguePanel;
    public bool timepassed = false;

    private bool onSite = false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue()
    {
        gameObject.GetComponent<PlayerActivate>().deactivate();
        sentences.Clear(); //borra el listado para empezar desde 0.
        dialoguePanel.SetActive(true);
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
        else { 
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

    private void Update()
    {
        if (displayText.text == activeSentence)
        {
            DisplayNextSentence();
        }

        if (displayText.text == "                 ")
        {
            GameObject.FindGameObjectWithTag("MiniSkeleton").GetComponent<Enemy>().enabled = true;
            startTime(4);
            if (!instanciated)
            {
                if (timepassed)
                {
                    gameObject.GetComponent<PlayerActivate>().activate();
                    instanciated = Instantiate(instruction, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform);
                }

            }
        }
        if (instanciated && Input.GetButtonDown("Fire1"))
        {
            instanciated.GetComponent<Animator>().SetTrigger("Vanish");
            Destroy(instanciated, 1);
            Destroy(gameObject, 1);
        }
    }

    private void startTime(int v)
    {
        Invoke("Void", v);
    }
    private void Void()
    {
        timepassed = true;
    }
}
