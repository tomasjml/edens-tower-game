using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    public GameObject _TriggerEffect;
    public string _Scene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.CompareTag("Trap"))
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if(collision.gameObject.GetComponent<PlayerHealth>().getCurrentHealth() > 0)
                {
                    collision.gameObject.transform.position = _TriggerEffect.transform.position;
                    Debug.Log(collision.gameObject.transform.position);
                }
                else
                {
                    SceneManager.LoadScene(_Scene);
                }
                
            }
        }
    }

}
