using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOfEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemiesPrefabs;
    private bool allEnemiesInThatPositionHaveDied=false;
    private bool allowInstantiate=true;
    private int index=0;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(allEnemiesInThatPositionHaveDied==false && allowInstantiate==true){
            int amount=0;
            Vector2 pos=transform.position;
            while(amount<3 && index<enemiesPrefabs.Length){
                pos=transform.position;
                GameObject skeleton= Instantiate(enemiesPrefabs[index],pos,Quaternion.identity);
                skeleton.transform.Rotate(0f,180f,0f);
                _rigidbody=skeleton.GetComponent<Rigidbody2D>();
                //pos.x=pos.x+(amount*-2);
                if(amount==0){
                    pos.x=0.1f;
                }else if (amount==1){
                    pos.x*=(amount*-1f);
                }else{
                    pos.x*=(amount*-0.75f);
                }
                _rigidbody.velocity = new Vector2(pos.x, _rigidbody.velocity.y);
                amount++;
            }
            index++;
            allowInstantiate=false;
        }
    }
}
