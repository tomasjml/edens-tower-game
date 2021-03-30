using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 _currentSpeed=new Vector3();
    Vector3 _deltaPos=new Vector3();
    bool  _shooted=true;
   
    void Update(){
        
        if(!_shooted){
            return;
        }
        
        _deltaPos=_currentSpeed*Time.deltaTime+Physics.gravity*Mathf.Pow(Time.deltaTime,2)/2;
        gameObject.transform.Translate(_deltaPos);
        _currentSpeed+=Physics.gravity*Time.deltaTime;
    }
    public void Shoot(Vector3 startingSpeed, float shootingAngle){
        _currentSpeed=new Vector3(startingSpeed.x*Mathf.Cos(shootingAngle),startingSpeed.y*Mathf.Sin(shootingAngle));
        _shooted=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			collision.SendMessageUpwards("AddDamageEnemy", 1);
			Debug.Log("Se esta enviando");
            Destroy(gameObject.gameObject);
		}
	}
    void OnCollisionEnter2D(Collision2D col){
        if (col.collider.tag!="Enemy" && col.collider.tag!="Player"){
            Destroy(gameObject.gameObject);
        }
    }

}
