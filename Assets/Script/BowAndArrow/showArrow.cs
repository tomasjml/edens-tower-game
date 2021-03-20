using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float lauchForce;
    public GameObject Arrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        GameObject arrowIns= Instantiate(Arrow,transform.position,transform.rotation);
        //arrowIns.GetComponent<ArrowScript>().ShootArrow(gameObject);
        
    }
}
