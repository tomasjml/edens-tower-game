using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller: MonoBehaviour
{
    public float speed;
    private GameObject _target;
    public float minX;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
        }
    }

    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(gameObject.transform.position, _target.transform.position) > 0.05f)
        {
            _animator.SetBool("Iddle", false);
            Vector2 direction = _target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            yield return null;
        }
        _animator.SetBool("Iddle", true);
        transform.position = new Vector2(_target.transform.position.x, gameObject.transform.position.y);
        yield return null ;
    }





}