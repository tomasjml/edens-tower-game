using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSimple : MonoBehaviour
{
    public float speed = 1f;
    private GameObject _target;
    public float minX;
    public float maxX;
    private Animator _animator;
    private bool idle = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        idle = true;
        yield return null;

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

    

    void LateUpdate()
    {
        _animator.SetBool("Idle", idle);
    }
}
