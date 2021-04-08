using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circularBlade : MonoBehaviour
{
    GameObject centerObject;
    Vector3 currentPosition = new Vector3(), angle, currentSpeed = new Vector3(1,1,1);
    float currentDistance, scalarAceleration = 2f, shootingTime;

    // Update is called once per frame
    void Update()
    {
        angle = currentSpeed * Mathf.Clamp((Time.time - shootingTime), 0f, 5f) / currentDistance;
        Debug.Log(angle);
        currentPosition.x = centerObject.transform.position.x + currentDistance * Mathf.Cos(angle.x);
        currentPosition.y = centerObject.transform.position.y + currentDistance * Mathf.Sin(angle.y);
        gameObject.transform.position = currentPosition;

        currentSpeed.x += scalarAceleration * Time.deltaTime;
        currentSpeed.y += scalarAceleration * Time.deltaTime;
    }

    public void Shoot(GameObject center, float distance)
    {
        centerObject = center;
        currentDistance = distance;
        shootingTime = Time.time;
        //Destroy(gameObject);
    }
}
