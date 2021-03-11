using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    MeshRenderer _renderer;
    float speed = 0.1f, tempspeed;
    Vector2 position = new Vector2();
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {

    }

    void Update()
    {
        tempspeed = speed * (20 / gameObject.transform.position.z);
        position.x = position.x + tempspeed * Time.deltaTime;
        _renderer.material.mainTextureOffset = position;
    }
}