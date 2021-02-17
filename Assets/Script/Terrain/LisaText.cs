using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LisaText : MonoBehaviour
{
    string[] messages = { "Me pregunto si me queda algo por leer", "Que libro tan raro, ¿Por qué está ahí?", "¡¿Qué está pasando?!"};
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
        switch (trigger)
        {
            case 0:
                prefab.GetComponent<TextMeshProUGUI>().SetText(messages[0]);
                break;
            case 1:
                prefab.GetComponent<TextMeshProUGUI>().SetText(messages[1]);
                break;
            case 2:
                prefab.GetComponent<TextMeshProUGUI>().SetText(messages[2]);
                break;
        }

        GameObject instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;

        if (livingTime > 0f)
        {
            Destroy(instantiatedObject, livingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lisa"))
        {
            if (name.Equals("Trigger1"))
            {
                Instantiate(0);
            }
            if (name.Equals("Trigger2"))
            {
                Instantiate(1);
            }
            if (name.Equals("Trigger3"))
            {
                Instantiate(2);
            }
        }
    }


}
