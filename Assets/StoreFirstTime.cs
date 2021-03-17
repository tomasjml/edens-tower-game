using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreFirstTime : MonoBehaviour
{
    public Canvas canvas;
    private Animator _animator;
    public GameObject player; 
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(true);
        //player.SendMessageUpwards("enableKeys", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
