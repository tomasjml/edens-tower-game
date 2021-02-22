
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Timer Attributes
    private TimeSpan timePlaying;
    private bool timerGoing;
    public float elapsedTime;
    private string timePlayingStr;
    private Text timeCounter;
    public bool timerRunning;

    // Game over Attributes
    public float restartDelay=2.5f;
    public bool gameEnded=false;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    protected GameManager() { }

    void InitGame()
    {

    }

    private void Start()
    {
        timeCounter.text = "Time playing: 00:00.00";
        timerGoing = false;
    }

    public void BeginGameManager()
    {
        timerGoing = true;

        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
        Debug.Log("Start Coroutine Update Timer Started!");
    }


    private void Update()
    {
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        timerRunning = true;
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = "Time playing: " + timePlaying.ToString("HH ':'mm':'ss");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
        timerRunning = false;
    }

    public void NewGame()
    {
        BeginGameManager();
        SceneManager.LoadScene("Dormitorio Lisa");
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public void EndGame(){
        if(gameEnded==false){
            gameEnded=true;
            Debug.Log("GAME OVER !");
            Debug.Log(timePlayingStr);
            Invoke("Restart",restartDelay);
            //Restart();
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
