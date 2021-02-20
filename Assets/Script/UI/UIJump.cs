using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIJump : MonoBehaviour
{
    public GameObject instruction;
    public Transform position;
    public Animator _animator;

    private GameObject instantiatedObject;
    private bool jump = false;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Jungla")){
            if (Input.GetButtonDown("Jump") && !_animator.GetBool("isGrounded"))
            {
                if (instantiatedObject)
                {
                    instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
                }
                Invoke("DestroyO", 1);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (instantiatedObject)
                {
                    instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
                }
                Invoke("DestroyO", 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!jump)
            {
                instantiatedObject = Instantiate(instruction, position.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;
                jump = true;
            }

        }
    }
    void DestroyO()
    {
        DestroyImmediate(instantiatedObject, true);
    }
}