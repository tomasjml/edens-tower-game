using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectUI : MonoBehaviour
{
    public Vector2 parallaxMultiplier;
    public float parallaxLimitX;
    public float parallaxLimitY;
    private Vector3 initialPos;
    private Vector3 deltaMovement;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        deltaMovement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaMovement.x /= parallaxMultiplier.x;
        deltaMovement.y /= parallaxMultiplier.y;
        deltaMovement.z = 0;

        //Check the movement limits
        if (initialPos.x - transform.position.x + deltaMovement.x < parallaxLimitX &&
            initialPos.x + transform.position.x - deltaMovement.x < parallaxLimitX &&
            initialPos.y - transform.position.y + deltaMovement.y < parallaxLimitY &&
            initialPos.y + transform.position.y - deltaMovement.y < parallaxLimitY)
        {
            this.transform.position -= deltaMovement;
        }
    }
}
