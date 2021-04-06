using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOfFlyingEnemies : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    private bool allowInstantiate=true;
    private int index=0;
    private Rigidbody2D _rigidbody;
    //private GameObject[] aliveEnemies;
    private List<GameObject> aliveEnemies = new List<GameObject>();
    private int amount,all;
    public GameObject limit;
    public GameObject firstLimit;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(firstLimit.activeSelf==false){
            if( allowInstantiate==true){
                player.GetComponent<PlayerControllerV2>().EnableBow(true);
                amount=0;
                Vector2 pos=transform.position;
                while(amount<1 && index<enemiesPrefabs.Length){
                    pos=transform.position;
                    pos.x+=(amount*-1.5f);
                    GameObject bird= Instantiate(enemiesPrefabs[index],pos,Quaternion.identity);
                    aliveEnemies.Insert(amount,bird);
               
                    amount++;
                }
                index++;
                allowInstantiate=false;
            }
            all=0;
            foreach (GameObject c in aliveEnemies){
                if(c.activeSelf){
                    break;
                }else{
                    all++;
                }
            }
            if(all%1==0 && all!=0){
                allowInstantiate=true;
            }
            if(index==enemiesPrefabs.Length && all>=1){
                limit.SetActive(false);
                allowInstantiate=false;
                player.GetComponent<PlayerControllerV2>().EnableBow(false);
            }
        }
    }
}
