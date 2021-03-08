using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectUI : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxMultiplier;
    [SerializeField] private float parallaxLimit;
    [SerializeField] private Transform origin;
    private Vector3 initialPos;
    private Vector3 deltaMovement;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        deltaMovement = origin.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = origin.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position -= new Vector3((deltaMovement.x * parallaxMultiplier.x), (deltaMovement.y * parallaxMultiplier.y));
    }
}
