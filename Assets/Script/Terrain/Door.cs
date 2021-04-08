using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("FX Puerta")]
    private AudioSource fxDoor;
    public AudioClip _OpenDoor;
    public AudioClip _CloseDoor;
    [SerializeField] private string nextLevel;
    private BoxCollider2D _collider;
    private Animator _animator;
    public GameObject _ImagePress;
    public Transform _ImagePosition;

    private GameObject instantiatedObject;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        fxDoor = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Door"))
        {
            _animator.SetBool("IsOpened", true);
            fxDoor.PlayOneShot(_OpenDoor,0.5f);
            instantiatedObject = Instantiate(_ImagePress,_ImagePosition.position, Quaternion.identity, GameObject.FindGameObjectWithTag("HUD").transform) as GameObject;

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.GetComponent<Animator>().GetBool("Enter"))
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (CompareTag("Door"))
        {
            _animator.SetBool("IsOpened", false);
            fxDoor.PlayOneShot(_CloseDoor,0.5f);
            instantiatedObject.GetComponent<Animator>().SetTrigger("Vanish");
            Invoke("DestroyO", 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyO()
    {
        DestroyImmediate(instantiatedObject, true);
    }

}

