using System.Collections;
using System.Collections.Generic;
using Cinemachine; 
using UnityEngine;

public class LimitConfiner : MonoBehaviour
{
    public void changeConfiner(PolygonCollider2D new_Confiner)
    {
        gameObject.GetComponent<CinemachineConfiner>().m_BoundingShape2D = new_Confiner;
    }

}
