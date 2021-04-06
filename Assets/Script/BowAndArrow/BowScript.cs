using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction;
    Vector3 startingSpeed;
    const float SCALAR_SPEED=10f;
    float currentAngle,deltaY,deltaX;
    Vector3 userInput=new Vector3();
    public GameObject Arrow;
    private ArrowScript arrowScript;

    void Start()
    {
        startingSpeed=new Vector3(SCALAR_SPEED,SCALAR_SPEED);
    }

    // Update is called once per frame
    void Update()
    {
        userInput=Camera.main.ScreenToWorldPoint(Input.touchSupported&&Input.touchCount > 0 ? 
        (Vector3)Input.GetTouch(0).position : Input.mousePosition);
        deltaY=userInput.y - gameObject.transform.position.y;
        deltaX=userInput.x-gameObject.transform.position.x;
        currentAngle=Mathf.Atan(deltaY/deltaX);
        Debug.Log("current angle "+currentAngle);

        Vector2 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos= transform.position;
        direction=mousePos-bowPos;
        FaceMouse();

        if(Input.GetButtonDown("Fire1")){
            Instantiate(Arrow,transform.position,transform.rotation).GetComponent<ArrowScript>().Shoot(startingSpeed,currentAngle);
        }
    }
    void FaceMouse(){
        transform.right=direction;
    }
}
