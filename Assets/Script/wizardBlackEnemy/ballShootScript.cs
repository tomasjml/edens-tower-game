using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector3 _currentSpeed=new Vector3();
    Vector3 _deltaPos=new Vector3();
    bool  _shooted=true;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        
        if(!_shooted){
            return;
        }
        
        _deltaPos=_currentSpeed*Time.deltaTime+Physics.gravity*Mathf.Pow(Time.deltaTime,2)/2;
        gameObject.transform.Translate(_deltaPos);
        _currentSpeed+=Physics.gravity*Time.deltaTime;
    }
    public void ShootBall(Vector3 startingSpeed, float shootingAngle){
        _currentSpeed=new Vector3(-1*startingSpeed.x*Mathf.Cos(shootingAngle),startingSpeed.y*Mathf.Sin(shootingAngle));
        _shooted=true;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		
			if (collision.CompareTag("Player"))
			{
				
				collision.SendMessageUpwards("AddDamage", 1);
				Debug.Log("Se esta enviando");
                Destroy(gameObject);
			}

		
	}
    }
