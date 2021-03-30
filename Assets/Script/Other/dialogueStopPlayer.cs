using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueStopPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogue;
    public GameObject character;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb=character.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
         movement = new Vector2(horizontalInput, 0f);
        if(dialogue.activeSelf==true){
            Debug.Log("hiiii");
            movement=Vector3.zero;

        }
    }
}
