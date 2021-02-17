using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class PlayerControllerV2 : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 2.5f;
    public Transform groundCheck;
    public LayerMask groundedLayers;
    public float groundCheckBaridus;
    private Rigidbody2D _body;
    private Animator _animator;
    
    private Vector2 _movement;
    private bool facingRight = true;
    public bool _isGrounded = true;
    private float counter = 0;

    private bool atacking = false;
    private int colPicas;

    private int veces;
    public int jumpsWanted;
    private bool isJumping=false;

    public Transform pica;
    public Transform vacio;
    private GameObject _target;
public float minX;
    public float maxX;
    public float waitingTime = 2f;
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        veces=0;
        colPicas=0;
        UpdateTarget();
        //var picas = Instantiate(pica) as Transform;
        //var vacioDie = Instantiate(vacio) as Transform;
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetTrigger("Enter");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (!atacking)
        {
            _movement = new Vector2(horizontalInput, 0f);
        }

        if (horizontalInput < 0f && facingRight == true)
        {
            flip();
        }
        else if (horizontalInput > 0f && facingRight == false)
        {
            flip();
        }

         _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckBaridus, groundedLayers);
        
        //Esta saltando?
        if(Input.GetButtonDown("Jump") &&  veces==0 && _isGrounded==true){
            _body.AddForce(Vector2.up *jumpForce, ForceMode2D.Impulse);
            isJumping=true;
            veces++;
            
        }

        else if(Input.GetButtonDown("Jump") && veces<jumpsWanted &isJumping==true){
            _body.AddForce(Vector2.up *jumpForce, ForceMode2D.Impulse);
           veces++;
        }
        if( veces==jumpsWanted){
            veces=0;
            isJumping=false;
        }    
        if (_movement == Vector2.zero && !atacking)
        {
            counter += 1 * Time.deltaTime;
        }
        else
        {
            counter = 0;
        }
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckBaridus, groundedLayers);
        if(transform.position.x>65){
            //Debug.Log("llego a 75");
            StartCoroutine("PatrolToTarget");
        }
    }
    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _body.velocity = new Vector2(horizontalVelocity, _body.velocity.y);
    }
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity",_body.velocity.y);
    }

    private void flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX *= -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }
    
    void OnCollisionEnter2D(Collision2D collisionInfo){
        
       if(collisionInfo.collider.tag=="Die"){
            colPicas++;
        }
        if(colPicas==1){
          Physics2D.IgnoreCollision(pica.GetComponent<Collider2D>(), GetComponent<Collider2D>());
          Physics2D.IgnoreCollision(vacio.GetComponent<Collider2D>(), GetComponent<Collider2D>());
          colPicas=0;
        FindObjectOfType<GameManager>().endGame();
        }
    }
private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            _animator.SetBool("Idle", false);
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * 0.01f * Time.deltaTime);
            _animator.SetBool("isGrounded", _isGrounded);
            yield return null;
        }
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        _animator.SetBool("Idle", true);
        yield return new WaitForSeconds(waitingTime);

    }
}