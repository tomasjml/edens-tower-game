using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject _Enemy;

    // Update is called once per frame
    void Update()
    {
        if(_Enemy.GetComponent<BossHealth>().getCurrentHealthEnemy() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
