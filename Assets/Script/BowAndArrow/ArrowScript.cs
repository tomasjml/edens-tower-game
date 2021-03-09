using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
    }
    void TrackMovement(){
        Vector2 direction=rb.velocity;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);

    }
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		
			if (collision.CompareTag("Enemy"))
			{
				
				collision.SendMessageUpwards("AddDamageEnemy", 1);
				Debug.Log("Se esta enviando");
                Destroy(gameObject);
			}

		
	}
}
