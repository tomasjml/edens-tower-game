using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRain : MonoBehaviour
{
    public GameObject[] _Objects;
    float _lastTime = 0, _nextTime;
    Vector3 _startingPos = new Vector3(0, 0f);
    const float minTime = 0.2f, maxTime = 0.6f, minx = 59f, maxx = 74f;
    int aux = 0;
    void Start()
    {
        _nextTime = GetNextTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextTime && aux < 30)
        {
            _startingPos.x = Random.Range(maxx, minx);
            Instantiate(_Objects[Random.Range(0,2)], _startingPos, Quaternion.identity);
            _nextTime = GetNextTime();
            aux++;
        }

    }

    float GetNextTime()
    {
        return Time.time + Random.Range(minTime, maxTime);
    }
}
