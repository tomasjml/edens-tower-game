using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamerasScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activateBookCamera;
    public GameObject bookCamera;
    public GameObject playerCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activateBookCamera==null || activateBookCamera.activeSelf==false){
            bookCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
}
