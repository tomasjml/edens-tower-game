using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOfEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemiesPrefabs;
    private bool allowInstantiate=true;
    private int index=0;
    private Rigidbody2D _rigidbody;
    //private GameObject[] aliveEnemies;
    private List<GameObject> aliveEnemies = new List<GameObject>();
    private int amount,all;
    public GameObject limit;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if( allowInstantiate==true){
            player.GetComponent<PlayerControllerV2>().EnableBow(false);
            amount=0;
            Vector2 pos=transform.position;
            while(amount<3 && index<enemiesPrefabs.Length){
                pos=transform.position;
                pos.x-=(amount*1.2f);
                GameObject skeleton= Instantiate(enemiesPrefabs[index],pos,Quaternion.identity);
                aliveEnemies.Insert(amount,skeleton);
                skeleton.GetComponent<Enemy>().flip();
                _rigidbody=skeleton.GetComponent<Rigidbody2D>();
                pos.x=transform.position.x;
                if(amount==0){
                    pos.x=0.1f;
                }else if (amount==1){
                    pos.x*=(amount*-1f);
                }else{
                    pos.x*=(amount*-0.7f);
                }
                _rigidbody.velocity = new Vector2(pos.x, _rigidbody.velocity.y);
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
        if(all%3==0 && all!=0){
            allowInstantiate=true;
        }
        if(index==enemiesPrefabs.Length && all==6){
            limit.SetActive(false);
            allowInstantiate=false;
            player.GetComponent<PlayerControllerV2>().EnableBow(true);
        }
    }
    
}
