using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LisaController : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private Animator _a;

    private bool idle = true;
    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        _a = GetComponent<Animator>();
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    private void UpdateTarget()
    {
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(maxX, transform.position.y);
            return;
        }
    }

    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            idle = false;
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null;
        }

        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        idle = true;
        new WaitForSeconds(waitingTime);
        StartCoroutine("ToJungle");

    }

    private IEnumerator ToJungle()
    {
        _a.applyRootMotion = false;
        _a.SetTrigger("Book");
        new WaitForSeconds(waitingTime);

        yield return new WaitForSeconds(waitingTime);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (idle)
        {
            _a.SetBool("Idle", true);

        }
        else
        {
            _a.SetBool("Idle", false);
        }
    }
}
