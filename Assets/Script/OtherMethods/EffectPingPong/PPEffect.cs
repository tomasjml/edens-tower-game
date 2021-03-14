using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPEffect : MonoBehaviour
{
    public float _speed = 5f;
    
    public float limMax = 28f;
    public float limMin = 0f;
    Vector3 currentPos = new Vector3();
    public GameObject _Plataforma;

    void Start()
    {
        currentPos = new Vector3(gameObject.transform.position.x ,gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos.x = limMin + Mathf.PingPong(Time.time * _speed, limMax);
        gameObject.transform.position = currentPos;
    }
}
