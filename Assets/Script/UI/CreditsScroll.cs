using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    private Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1);
    }

    private void OnDisable()
    {
        transform.position = InitialPosition;
    }
}
