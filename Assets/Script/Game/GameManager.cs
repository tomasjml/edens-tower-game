
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay=1.5f;
    public bool gameEnded=false;
    public void endGame(){
        if(gameEnded==false){
            gameEnded=true;
            Debug.Log("GAME OVER HOE");
            Invoke("Restart",restartDelay);
            //Restart();
        }
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
