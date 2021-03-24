using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos= transform.position;
        direction=mousePos-bowPos;
        FaceMouse();
    }
    void FaceMouse(){
        transform.right=direction;

    }
}
