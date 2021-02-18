using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisaText : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public float livingTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiate(int trigger)
    {
        GameObject instantiatedObject = null;
        switch (trigger)
        {
            case 0:
                instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Lisa").transform) as GameObject;
                break;
            case 1:
                instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Player").transform) as GameObject;
                float scalex = instantiatedObject.transform.localScale.x * -1;
                instantiatedObject.transform.localScale = new Vector3(scalex, instantiatedObject.transform.localScale.y, instantiatedObject.transform.localScale.z);
                break;
        }
        
        if (livingTime > 0f)
        {
            Destroy(instantiatedObject, livingTime);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lisa"))
        {
            Instantiate(0);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(1);
            Destroy(this.gameObject);
        }
 

        
    }


}
