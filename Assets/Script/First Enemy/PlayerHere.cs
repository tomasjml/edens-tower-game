using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHere : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Position;
    private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 p = Position.transform.position;
        Instantiate(enemy, p, Quaternion.identity);
        Debug.Log("Se esta haciendo!");
        Destroy(this);
    }

// Update is called once per frame
    void Update()
    {
 
    }

}