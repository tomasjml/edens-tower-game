using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCoontroller : MonoBehaviour
{

    private GameObject _target;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;
    private SpriteRenderer mySpriteRenderer ;
    public Transform player;
    public Transform startDialoguePosition;
    public DialogTrigger dialogueTrigger;
    private PlayerControllerV2 playerScript;
    private DialogManager dialogManag;
    public Transform dialogueManagerObject;
    private int veces=0;
    public Transform textBoxSprite;
    private SpriteRenderer orderLayerTextboxSprite;
    void Awake()
    {
       mySpriteRenderer = GetComponent<SpriteRenderer>();
         orderLayerTextboxSprite=textBoxSprite.gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        playerScript=player.gameObject.GetComponent<PlayerControllerV2>();
        dialogueTrigger=startDialoguePosition.gameObject.GetComponent<DialogTrigger>();
        dialogManag= dialogueManagerObject.gameObject.GetComponent<DialogManager>();
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
        
        if(player.transform.position.x>0.293){
            StartCoroutine("PatrolToTarget");
            mySpriteRenderer.sortingOrder=0;
            playerScript.enableKeys(false);
        }
        if(transform.position.x<=startDialoguePosition.transform.position.x && veces==0){
            orderLayerTextboxSprite.sortingOrder=0;
            dialogueTrigger.TriggerDialogue();
            veces++;
        }
        if(Input.GetKeyDown(KeyCode.W)){
            dialogManag.DisplayNextSentence();
        }
        if(dialogManag.isDialogueialogueFinished()==true){
            mySpriteRenderer.sortingOrder=-1;
            playerScript.enableKeys(true);
            Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
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

            transform.Translate(direction.normalized * 0.002f * Time.deltaTime);
            //_animator.SetBool("isGrounded", _isGrounded);
            yield return null;
        }
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        //_animator.SetBool("Idle", true);
        yield return new WaitForSeconds(waitingTime);

    }
}
