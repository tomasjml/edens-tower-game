using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsigParent : MonoBehaviour
{
    public GameObject _Player;
    public bool _isOnMovingPlatform = false;
    public GameObject _Player_Parent;

    // Update is called once per frame
    void Update()
    {
        if(_isOnMovingPlatform == true)
        {
            _Player.transform.SetParent(this.transform);
        }
        else
        {
            _Player.transform.SetParent(_Player_Parent.transform);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _isOnMovingPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _isOnMovingPlatform = false;
        }
    }
}