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
    private bool enter = false;
    private GameObject _target;

    private void Awake()
    {
        _a = GetComponent<Animator>();        
    }
    // Start is called before the first frame update
    void Start()
    {
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
        enter = true;
        idle = true;
        yield return null;

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        _a.SetBool("Idle", idle == true);
        if(enter)
        {
            transform.position = new Vector2(0.4676723f, -3.027581f);
            _a.applyRootMotion = false;
            _a.SetTrigger("Book");
        }
    }
    void desactivate()
    {

        new WaitForSeconds(10);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("Context 2");
    }
}
