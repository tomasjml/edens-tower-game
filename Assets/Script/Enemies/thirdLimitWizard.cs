using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdLimitWizard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject characterToDie;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(characterToDie.activeSelf==false){
            this.gameObject.SetActive(false);
        }
    }
}
