using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueStopPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogCloud;
    private Rigidbody2D _rigidbody;
    Animator _animator;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogCloud!=null &&dialogCloud.activeSelf){
            Debug.Log("la nube is active hoe");
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
        }
    }
}
