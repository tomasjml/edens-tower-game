using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhablitateWizardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogCloud;
    private Rigidbody2D _rigidbody;
    Animator _animator;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogCloud.activeSelf){
            Debug.Log("Nube ha sido actividada");
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("idle", _rigidbody.velocity == Vector2.zero);
        }
    }
}
