using UnityEngine;


public class DialogScript : MonoBehaviour
{
    public GameObject _Prefab;
    public Transform _Position;

    public float livingTime;

    private GameObject prefabInstantiate;


    public GameObject[] _pr;
    // Start is called before the first frame update

    void Awake()
    {
        
    }  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prefabInstantiate = Instantiate(_Prefab, _Position.position, Quaternion.identity, GameObject.FindWithTag("HUD").transform) as GameObject;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(prefabInstantiate,livingTime);
        }
        
    }



     
}
