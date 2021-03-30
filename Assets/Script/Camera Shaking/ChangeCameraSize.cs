using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraSize : MonoBehaviour
{
    // Start is called before the first frame update
    public float positionX=0f;
    public int OrthopedicSizeWanted;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    public GameObject player;

    void Start()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position.x);
        if (player.transform.position.x>positionX){
            Debug.Log("entotr ala positiojn");
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = OrthopedicSizeWanted;
        }
    }
}
