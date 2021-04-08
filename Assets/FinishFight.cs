using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFight : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            finish();
        }
    }
    public void finish()
    {

    }
}
