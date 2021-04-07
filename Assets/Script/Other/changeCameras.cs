using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCameras : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerCamera;
    public GameObject storyCamera;
    public GameObject player;
    private Rigidbody2D _rigidbody;
    private bool onSite=false;
    int cant=0;
    void Start()
    {
        _rigidbody=storyCamera.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (player.gameObject.GetComponent<Rigidbody2D>().velocity==Vector3.zero){
            if(Input.GetKeyDown(KeyCode.E) && cant<3 &&onSite==true){
                cant++;
            }
            if(cant>=3){
                playerCamera.SetActive(false);
                storyCamera.SetActive(true);
                if(storyCamera.transform.position.x<278){
                    _rigidbody.velocity = new Vector2(4f, _rigidbody.velocity.y);
                }
                else{
                    _rigidbody.velocity = Vector3.zero;
                }
                
            }
       // }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            onSite=true;
        }
    }
}
