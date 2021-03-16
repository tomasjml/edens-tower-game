using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    Vector3 _PointSave;
    // Update is called once per frame
    private void Awake()
    {
       
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _PointSave = other.transform.position;
            Debug.Log(_PointSave);
        }
    }

    public Vector3 GetLastPosition()
    {
        return _PointSave;
    }
}
