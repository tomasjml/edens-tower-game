using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiesStand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    public GameObject graveOne;
    public GameObject graveTwo;
    private bool pressEAgain=false;
    public GameObject storyFinished;
    void Start()
    {
        GameObject zombie1=Instantiate(zombie,graveOne.transform.position,graveOne.transform.rotation);
        GameObject zombie2=Instantiate(zombie,graveTwo.transform.position,graveTwo.transform.rotation);
        zombie1.GetComponent<Animator>().SetBool("idle",true);
        zombie2.GetComponent<Animator>().SetBool("idle",true);
        StartCoroutine(waitToPressE());
    }

    // Update is called once per frame
    void Update()
    {
        if(pressEAgain==true && Input.GetKeyDown(KeyCode.E)){
            storyFinished.SetActive(true);
            Debug.Log("story finished es true");
        }
    }
    IEnumerator waitToPressE()
    {
        
        yield return new WaitForSeconds(2);

        pressEAgain=true;
    }
}
