using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasesKaosTp : MonoBehaviour
{
    [Header("Kaos")]
    public GameObject _KaosFase;
    [Header("Zona TP")]
    public GameObject _FaseTP;
    public GameObject _Player;
    [Header("Cambio de camara")]
    public GameObject _CameraON;
    public GameObject _CameraOFF;
    float time;
    int cant = 0;

    private void Update()
    {
        if (_KaosFase.GetComponent<BossHealth>().getCurrentHealthEnemy() <= 0)
        {
            if(cant < 1)
            {
                time = getNextTime();
                cant++;
            }
            if (Time.time > time)
            {
                _Player.transform.position = _FaseTP.transform.position;
                _CameraOFF.SetActive(false);
                _CameraON.SetActive(true);
                Destroy(_FaseTP);
                

            }
        }
    }
 
    float getNextTime()
    {
        return Time.time + 5f;
    }
}
