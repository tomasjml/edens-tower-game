using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCoontroller : MonoBehaviour
{

    private GameObject _target;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;
    private Animator _animator;
    void Awake()
    {
       _animator=GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    private void UpdateTarget()
    {
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(maxX, transform.position.y);
            return;
        }
    }
    void Update()
    {
        
    }
    void LateUpdate(){
        
    }


    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
           // _animator.SetBool("Idle", false);
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * 0.004f * Time.deltaTime);
            //_animator.SetBool("isGrounded", _isGrounded);
            yield return null;
        }
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        //_animator.SetBool("Idle", true);
        yield return new WaitForSeconds(waitingTime);

    }
}