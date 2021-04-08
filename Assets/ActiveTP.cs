using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTP : MonoBehaviour
{
    [Header("Enemigo")]
    public GameObject _Kaos;
    public GameObject _BarraVKaos;
    [Header("TP")]
    public GameObject _TP;

    

    // Update is called once per frame
    void Update()
    {
        if(_Kaos.GetComponent<BossHealth>().getCurrentHealthEnemy() <= 0)
        {
            _TP.SetActive(true);
            _BarraVKaos.SetActive(false);
        }
    }
}
