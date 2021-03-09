using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class En_Spawn : MonoBehaviour
{
   public Transform _Spawn;
   public GameObject _Enemy;
   private GameObject spw;

   private void OntTriggerEnter2D(Collider2D other)
   {
       spw = Instantiate(_Enemy,_Spawn.position,Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy").transform) as GameObject;
   }

   
}
