
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;

    static public GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                // creamos un nuevo objeto llamado "_MiGameManager"
                GameObject go = new GameObject("_MiGameManager");

                // anadimos el script "GameManager" al objeto
                go.AddComponent<GameManager>();

                // guardamos en la instancia el objeto creado
                // debemos guardar el componente ya que _instancia es del tipo GameManager
                _instance = go.GetComponent<GameManager>();

                // hacemos que el objeto no se elimine al cambiar de escena
                DontDestroyOnLoad(go);
            }

            // devolvemos la instancia
            // si no existia, en este punto ya la habra creado
            return _instance;
        }
    }

    protected GameManager() { }

    public float restartDelay=2.5f;
    public bool gameEnded=false;
    public void endGame(){
        if(gameEnded==false){
            gameEnded=true;
            Debug.Log("GAME OVER ");
            Invoke("Restart",restartDelay);
        }
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
