using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPEffect : MonoBehaviour
{
    public float _speed = 5f;
    
    public float limMax = 28f;
    public float limMin = 0f;
    Vector3 currentPos = new Vector3();
    public bool _effectX;
    public bool _effectY;

    void Start()
    {
        currentPos = new Vector3(gameObject.transform.position.x ,gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(_effectX == true) currentPos.x = limMin + Mathf.PingPong(Time.time * _speed, limMax);
        if (_effectY == true) currentPos.y = limMin + Mathf.PingPong(Time.time * _speed, limMax);
        gameObject.transform.position = currentPos;
    }
}
