using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class DialogManagerV4 : MonoBehaviour
{
    public Dialogue dialogue;
    public Text displayText;

    Queue<string> sentences;
    string activeSentence;
    public float typingString;
    public GameObject dialoguePanel;
    public GameObject[] ObjectsDestroy;


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

        if (Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence && onSite)
        {
            DisplayNextSentence();
        }

        if (sentences.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && onSite)
            {
                foreach (GameObject c in ObjectsDestroy){
                    Destroy(c, 0);
                }
            }
        }
    }


}
