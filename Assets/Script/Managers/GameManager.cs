
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
    private SaveAndLoad saveObject = null;
    

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

        // item build
        Instantiate(itemManagement);
        DontDestroyOnLoad(itemManagement);

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
        itemManagement.BuildItems();

        timerGoing = true;

        //elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
        Debug.Log("Start Coroutine Update Timer Started!");
    }


    private void Update()
    {
        
        
    }

    private IEnumerator UpdateTimer()
    {
        timerGoing = true;
        float initialTime = 0f;
        timerRunning = true;
        while (timerGoing)
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
        saveData.difficulty = SaveData.Difficulty.Easy;
        StartCoroutine(UpdateTimer());
        BeginGameManager();
        SceneManager.LoadScene("Context");
    }

    public void LoadRequest(string slot)
    {

        if (saveObject == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Pause");
            saveObject = (SaveAndLoad)gameObject.GetComponent(typeof(SaveAndLoad));
        }
        saveObject.LoadGame(slot);
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
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;

        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //player.transform.position = position;
        StartCoroutine(UpdateTimer());
    }

    public void SaveGame(String slot)
    {
        if(saveObject == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Pause");
            saveObject = (SaveAndLoad)gameObject.GetComponent(typeof(SaveAndLoad));
        }
        saveObject.SaveGame(slot);
        saveObject.LoadUserGame();
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    public void EndGame() 
    {
        if(gameEnded == false) {
            gameEnded=true;
            Debug.Log("GAME OVER !");
            Debug.Log(timePlayingStr);
            Invoke("Restart",restartDelay);
            //Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ======= Market Functions
    public void MarketBuyItem(string title, int quantity)
    {
        Item itemPurchased = itemManagement.GetItemByTitle(title);
        saveData.playerData.inventory[itemManagement.GetItemByTitle("Magic Stone")] -= itemPurchased.stats["value"] * quantity;
        saveData.playerData.AddItemToInventory(itemPurchased, quantity);
    }

    public void MarketSellItem(string title, int quantity)
    {
        Item itemSold = itemManagement.GetItemByTitle(title);
        saveData.playerData.inventory[itemManagement.GetItemByTitle("Magic Stone")] += itemSold.stats["value"] * quantity;
        saveData.playerData.RemoveItemToInventory(itemSold, quantity);
    }
}
