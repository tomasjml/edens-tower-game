using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] _Enemies;
    public GameObject Muro;

    public float min = 8f, max = 10f;

    float nextTime;
    int ido = 0;

    private void Start()
    {
        nextTime = getNextTime();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime && ido < 8)
        {
            Instantiate(_Enemies[Random.Range(0, 4)], gameObject.transform.position, Quaternion.identity);
            nextTime = getNextTime();
            ido++;

        }

        if (ido == 8)
        {
            Muro.SetActive(false);
        }

    }

    float getNextTime()
    {
        return Time.time + Random.Range(min, max);
    }
}
