using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using SimpleJSON;
using static System.Linq.Enumerable;


public class SaveAndLoad : MonoBehaviour
{
    public enum Slot {One, Two, Three, Four};

    private Vector3 position;
    private readonly string serviceURL = "http://161.35.251.140:8086/";
    private GameObject player;
    public string username;
    public Slot slot;

    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;

    //public static SaveAndLoad instance;



    public void LoadGame(string slot)
    {
        username = GameManager.instance.user;
        StartCoroutine(GetRequest(slot));
    }

    public void LoadUserGame()
    {
        username = GameManager.instance.user;
        StartCoroutine(GetGamesRequest());
    }


    public void SaveGame(string slot)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        position = player.transform.position;
        GameManager.instance.saveData.playerData.position = position;
        GameManager.instance.saveData.playerData.sceneName = SceneManager.GetActiveScene().name;
        string jsonSaveData = JsonUtility.ToJson(GameManager.instance.saveData);
        username = GameManager.instance.user;


        StartCoroutine(postRequest(jsonSaveData, slot));
    }


    public void DeleteGame()
    {
        username = GameManager.instance.user;
        StartCoroutine(DeleteRequest());
    }

    public void LoadHighScoreList()
    {
        StartCoroutine(getHighScore());
    }

    IEnumerator getHighScore()
    {
        UnityWebRequest GETRequest = UnityWebRequest.Get(serviceURL + "/users/highScore/");
        yield return GETRequest.SendWebRequest();

        if (GETRequest.result == UnityWebRequest.Result.ProtocolError || GETRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(GETRequest.error);
            yield break;
        }
        else
        {
            Debug.Log("Data Loaded");
        }

        Debug.Log(GETRequest.downloadHandler.text);

        JSONArray arrayGame = (JSONArray)JSON.Parse(GETRequest.downloadHandler.text);

        Dictionary<String, int> highscoreDict = new Dictionary<string, int>();

        foreach (JSONNode game in arrayGame)
        {
            String username = game["User"].Value;
            int highScore = Convert.ToInt32(game["Highscore"].Value);

            highscoreDict.Add(username, highScore);
        }

        var myList = highscoreDict.ToList();

        myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        foreach (KeyValuePair<String, int> pair in myList) { Debug.Log(pair.Key + ": " + pair.Value); }

        //1er lugar
        Text text_1Username = GameObject.Find("Positions/1st/Username").GetComponent<Text>();
        text_1Username.text = myList[0].Key;
        Text text_1Score = GameObject.Find("Positions/1st/Score").GetComponent<Text>();
        text_1Score.text = myList[0].Value.ToString();

        //2do lugar
        Text text_2Username = GameObject.Find("Positions/2nd/Username").GetComponent<Text>();
        text_2Username.text = myList[1].Key;
        Text text_2Score = GameObject.Find("Positions/2nd/Score").GetComponent<Text>();
        text_2Score.text = myList[1].Value.ToString();

        //3er lugar
        Text text_3Username = GameObject.Find("Positions/3rd/Username").GetComponent<Text>();
        text_3Username.text = myList[2].Key;
        Text text_3Score = GameObject.Find("Positions/3rd/Score").GetComponent<Text>();
        text_3Score.text = myList[2].Value.ToString();

        //4to lugar
        Text text_4Username = GameObject.Find("Positions/4th/Username").GetComponent<Text>();
        text_4Username.text = myList[3].Key;
        Text text_4Score = GameObject.Find("Positions/4th/Score").GetComponent<Text>();
        text_4Score.text = myList[3].Value.ToString();

        //5to lugar
        Text text_5Username = GameObject.Find("Positions/5th/Username").GetComponent<Text>();
        text_5Username.text = myList[4].Key;
        Text text_5Score = GameObject.Find("Positions/5th/Score").GetComponent<Text>();
        text_5Score.text = myList[4].Value.ToString();

        //6to lugar
        Text text_6Username = GameObject.Find("Positions/6th/Username").GetComponent<Text>();
        text_6Username.text = myList[5].Key;
        Text text_6Score = GameObject.Find("Positions/6th/Score").GetComponent<Text>();
        text_6Score.text = myList[5].Value.ToString();

        //7mo lugar
        Text text_7Username = GameObject.Find("Positions/7th/Username").GetComponent<Text>();
        text_7Username.text = myList[6].Key;
        Text text_7Score = GameObject.Find("Positions/7th/Score").GetComponent<Text>();
        text_7Score.text = myList[6].Value.ToString();

        //8vo lugar
        Text text_8Username = GameObject.Find("Positions/8th/Username").GetComponent<Text>();
        text_8Username.text = myList[7].Key;
        Text text_8Score = GameObject.Find("Positions/8th/Score").GetComponent<Text>();
        text_8Score.text = myList[7].Value.ToString();

        //9no lugar
        Text text_9Username = GameObject.Find("Positions/9th/Username").GetComponent<Text>();
        text_9Username.text = myList[8].Key;
        Text text_9Score = GameObject.Find("Positions/9th/Score").GetComponent<Text>();
        text_9Score.text = myList[8].Value.ToString();

        //10mo lugar
        Text text_10Username = GameObject.Find("Positions/10th/Username").GetComponent<Text>();
        text_10Username.text = myList[9].Key;
        Text text_10Score = GameObject.Find("Positions/10th/Score").GetComponent<Text>();
        text_10Score.text = myList[9].Value.ToString();

    }

    //Load
    IEnumerator GetRequest(string slot)
    {
        UnityWebRequest GETRequest = UnityWebRequest.Get(serviceURL + "games/game?slot="+ slot + "&username=" + username);
        yield return GETRequest.SendWebRequest();

        if (GETRequest.result == UnityWebRequest.Result.ProtocolError || GETRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(GETRequest.error);
            yield break;
        }
        else
        {
            Debug.Log("Data Loaded");
        }


        JSONNode gamedata = JSON.Parse(GETRequest.downloadHandler.text);

        GameManager.instance.LoadGame(gamedata);

        /*
        string loadDataJson = gamedata["saveData"];
        SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

        string sceneName = loadData.playerData.sceneName;
        position = loadData.playerData.position;


        GameManager.instance.elapsedTime = (int) gamedata["gameTimeInSeconds"];

        //Load Player stats
        GameManager.instance.saveData.playerData.defense = loadData.playerData.defense;
        GameManager.instance.saveData.playerData.speed = loadData.playerData.speed;
        GameManager.instance.saveData.playerData.strength = loadData.playerData.strength;
        GameManager.instance.saveData.playerData.luck = loadData.playerData.luck;
        GameManager.instance.saveData.playerData.vitality = loadData.playerData.vitality;

        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        //player.transform.position = position;
        */
    }

    //Load User Games
    IEnumerator GetGamesRequest()
    {
        Debug.Log("UsernameGames " + GameManager.instance.user);
        UnityWebRequest GETRequest = UnityWebRequest.Get(serviceURL + "games/username?username=" + username);
        yield return GETRequest.SendWebRequest();

        if (GETRequest.result == UnityWebRequest.Result.ProtocolError || GETRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(GETRequest.error);
            yield break;
        }
        else
        {
            Debug.Log("Data Loaded");
        }

        //Debug.Log(GETRequest.downloadHandler.text);

        JSONArray arrayGame = (JSONArray)JSON.Parse(GETRequest.downloadHandler.text);

        foreach(JSONNode game in arrayGame)
        {
            if (game["gameID"]["saveSlot"] == "One")
            {
                //tiempo
                Text textTime = GameObject.Find("Slot1/Time").GetComponent<Text>();
                string timeInSeconds = game["gameTimeInSeconds"].Value;
                int totalSeconds = Convert.ToInt32(timeInSeconds);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = (totalSeconds % 3600) % 60;
                textTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

                //lugar
                string loadDataJson = game["saveData"];
                SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

                string sceneName = loadData.playerData.sceneName;

                Text textPlace = GameObject.Find("Slot1/Area").GetComponent<Text>();
                textPlace.text = sceneName;

                //Dificultad
                Text textDifficulty = GameObject.Find("Slot1/Difficulty").GetComponent<Text>();
                textDifficulty.text = game["difficulty"];

                //slot1.onClick.AddListener(() => GameManager.instance.LoadGame(game));

                Debug.Log("Save slot 1");

            } 
            else if (game["gameID"]["saveSlot"] == "Two") {

                //tiempo
                Text textTime = GameObject.Find("Slot2/Time").GetComponent<Text>();
                string timeInSeconds = game["gameTimeInSeconds"].Value;
                int totalSeconds = Convert.ToInt32(timeInSeconds);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = (totalSeconds % 3600) % 60;
                textTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

                //lugar
                string loadDataJson = game["saveData"];
                SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

                string sceneName = loadData.playerData.sceneName;

                Text textPlace = GameObject.Find("Slot2/Area").GetComponent<Text>();
                textPlace.text = sceneName;

                //Dificultad
                Text textDifficulty = GameObject.Find("Slot2/Difficulty").GetComponent<Text>();
                textDifficulty.text = game["difficulty"];

                //slot2.onClick.AddListener(() => GameManager.instance.LoadGame(game));

                Debug.Log("Save slot 2");
            }
            else if (game["gameID"]["saveSlot"] == "Three")
            {
                //tiempo
                Text textTime = GameObject.Find("Slot3/Time").GetComponent<Text>();
                string timeInSeconds = game["gameTimeInSeconds"].Value;
                int totalSeconds = Convert.ToInt32(timeInSeconds);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = (totalSeconds % 3600) % 60;
                textTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

                //lugar
                string loadDataJson = game["saveData"];
                SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

                string sceneName = loadData.playerData.sceneName;

                Text textPlace = GameObject.Find("Slot3/Area").GetComponent<Text>();
                textPlace.text = sceneName;

                //Dificultad
                Text textDifficulty = GameObject.Find("Slot3/Difficulty").GetComponent<Text>();
                textDifficulty.text = game["difficulty"];

                //slot3.onClick.AddListener(() => GameManager.instance.LoadGame(game));

                Debug.Log("Save slot 3");
            }
            else if (game["gameID"]["saveSlot"] == "Four")
            {
                //tiempo
                Text textTime = GameObject.Find("Slot4/Time").GetComponent<Text>();
                string timeInSeconds = game["gameTimeInSeconds"].Value;
                int totalSeconds = Convert.ToInt32(timeInSeconds);
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = (totalSeconds % 3600) % 60;
                textTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

                //lugar
                string loadDataJson = game["saveData"];
                SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

                string sceneName = loadData.playerData.sceneName;

                Text textPlace = GameObject.Find("Slot4/Area").GetComponent<Text>();
                textPlace.text = sceneName;

                //Dificultad
                Text textDifficulty = GameObject.Find("Slot4/Difficulty").GetComponent<Text>();
                textDifficulty.text = game["difficulty"];

                //slot4.onClick.AddListener(() => GameManager.instance.LoadGame(game));

                Debug.Log("Save slot 4");
            }
                
        }
        yield break;

    }

    //Save
    IEnumerator postRequest(string jsonSaveData, string slot)
    {
        WWWForm form = new WWWForm();

        form.AddField("autoSave", "true");
        form.AddField("difficulty", GameManager.instance.saveData.difficulty.ToString());
        form.AddField("fullScreen", "true");
        form.AddField("gameTimeInSeconds", (int) GameManager.instance.elapsedTime);
        form.AddField("gammaLvl", 6);
        form.AddField("musicEnabled", GameManager.instance.saveData.bgmEnabled.ToString());
        form.AddField("musicLvl", GameManager.instance.saveData.bgmLvl);
        form.AddField("saveData", jsonSaveData);
        form.AddField("saveSlotstr", slot);
        form.AddField("sfxEnabled", GameManager.instance.saveData.seEnabled.ToString());
        form.AddField("sfxLvl", GameManager.instance.saveData.seLvl);
        form.AddField("defense", (int) GameManager.instance.saveData.playerData.defense);
        form.AddField("speed", (int) GameManager.instance.saveData.playerData.speed);
        form.AddField("strength", (int) GameManager.instance.saveData.playerData.strength);
        form.AddField("luck", (int) GameManager.instance.saveData.playerData.luck);
        form.AddField("vitality", (int)GameManager.instance.saveData.playerData.vitality);
        form.AddField("totalDeaths", 0);
        form.AddField("totalKills", 0);
        form.AddField("username", username);

        UnityWebRequest POSTRequest = UnityWebRequest.Post(serviceURL + "games/game", form);
        yield return POSTRequest.SendWebRequest();

        if (POSTRequest.result == UnityWebRequest.Result.ProtocolError || POSTRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(POSTRequest.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }


    }

    //Delete
    IEnumerator DeleteRequest()
    {
        UnityWebRequest DELRequest = UnityWebRequest.Delete(serviceURL + "games/game?saveSlotstr=" + slot.ToString() + "&username=" + username);
        yield return DELRequest.SendWebRequest();

        if (DELRequest.result == UnityWebRequest.Result.ProtocolError || DELRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(DELRequest.error);
            yield break;
        }
        else
        {
            Debug.Log("Game Deleted");
        }
    }


}
