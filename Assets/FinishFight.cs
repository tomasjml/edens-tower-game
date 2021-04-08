using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFight : MonoBehaviour
{
    public GameObject limitD;
    public GameObject limitA;
    public GameObject Camera;

    private void Update()

    {
        if (gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            finish();
        }
    }
    public void finish()
    {
        GameObject.Find("CameraFight").SetActive(false);
        Camera.SetActive(true);
        limitD.SetActive(false);
        limitA.SetActive(true);
    }
}
