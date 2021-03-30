using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSC : MonoBehaviour
{
    public GameObject _Player;
    public Transform _posTP;
    public GameObject cam1;
    public GameObject cam2;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _Player.transform.position = _posTP.position;
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
