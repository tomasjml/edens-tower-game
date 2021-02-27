
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Timer Attributes
    private TimeSpan timePlaying;
    private bool timerGoing;
    private string timePlayingStr;
    //private Text timeCounter;
    public bool timerRunning;
    public float elapsedTime;


    // Game over Attributes
    public float restartDelay=2.5f;
    public bool gameEnded=false;

    // Player Stats
    public SaveData saveData;

    // Item Management
    public ItemManagement itemManagement;

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

        // Item initiation
        itemManagement = new ItemManagement();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    protected GameManager() { }

    void InitGame()
    {

    }

    private void Start()
    {
        //timeCounter.text = "Time playing: 00:00.00";
        timerGoing = false;
    }

    public void BeginGameManager()
    {
        timerGoing = true;

        //elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
        Debug.Log("Start Coroutine Update Timer Started!");
    }


    private void Update()
    {
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        float initialTime = 0f;
        timerRunning = true;
        if (timerGoing)
        {
            initialTime = Time.deltaTime;
            elapsedTime += initialTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            //timePlayingStr = "Time playing: " + timePlaying.ToString("HH ':'mm':'ss");
            //timeCounter.text = timePlayingStr;

            yield return null;
        }
        timerRunning = false;
    }

    public void NewGame()
    {
        // Initial Stats 
        saveData.playerData.strength = 1;
        saveData.playerData.luck = 1;
        saveData.playerData.speed = 1;
        saveData.playerData.vitality = 1;
        saveData.playerData.defense = 1;
        elapsedTime = 0f;

        BeginGameManager();
        SceneManager.LoadScene("Context");
    }

    public void LoadGame(JSONNode game)
    {
        string loadDataJson = game["saveData"];
        SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

        string sceneName = loadData.playerData.sceneName;
        Vector2 position = loadData.playerData.position;

        elapsedTime = (float)game["gameTimeInSeconds"];
        //Debug.Log(TimeSpan.FromSeconds(elapsedTime).ToString("HH ':'mm':'ss"));

        saveData.playerData.defense = loadData.playerData.defense;
        saveData.playerData.speed = loadData.playerData.speed;
        saveData.playerData.strength = loadData.playerData.strength;
        saveData.playerData.luck = loadData.playerData.luck;
        saveData.playerData.vitality = loadData.playerData.vitality;

        BeginGameManager();
        SceneManager.LoadSceneAsync(sceneName);

       // GameObject player = GameObject.FindGameObjectWithTag("Player");

        //player.transform.position = position;
    }

    public void SaveGame(String slot)
    {
        SaveAndLoad.instance.SaveGame(slot);
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public void EndGame() {
        if(gameEnded == false) {
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
