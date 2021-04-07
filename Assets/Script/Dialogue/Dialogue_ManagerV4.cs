using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue_ManagerV4 : MonoBehaviour
{
    private const char V = ' ';
    public GameObject Health;
    public Text displayText;
    public string advice;
    string activeSentence;
    public float typingString;
    AudioSource myAudio;
    public AudioClip speakSound;
    public GameObject dialoguePanel;
    public GameObject _Trigger;
    public PlayerControllerV2 _Player;

    private GameObject instantiatedObject;

    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void DisplayNextSentence()
    {

        activeSentence = advice;
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
            DisplayNextSentence();
            Health.SetActive(true);
            Invoke("end", 3);
        }
        
    }

    public void end()
    {
        StartCoroutine(DeleteTheSentence(activeSentence));
    }

    IEnumerator DeleteTheSentence(string sentence)
    {
        Destroy(dialoguePanel);
        yield return null;
    }


}
