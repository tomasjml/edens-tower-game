using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour
{
    Vector3 deltaPos = new Vector3();
    Vector3 currentSpeed = new Vector3();
    // Update is called once per frame
    void Update()
    {
        deltaPos.y = currentSpeed.y * Time.deltaTime + Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2) / 2;
        gameObject.transform.Translate(deltaPos);
        currentSpeed += Physics.gravity * Time.deltaTime;
    }
}
