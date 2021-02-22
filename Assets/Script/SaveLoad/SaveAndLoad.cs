using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using SimpleJSON;


public class SaveAndLoad : MonoBehaviour
{

    public enum Slot {One, Two, Three, Four};

    public Vector2 position;
    private readonly string serviceURL = "http://161.35.251.140:8086/";
    public GameObject player;
    public string username;
    public Slot slot;



    private void Update()
    {
        position = player.transform.position;
    }

    public void SaveGame()
    {
        GameManager.instance.saveData.playerData.position = position;
        GameManager.instance.saveData.playerData.scene = SceneManager.GetActiveScene();
        string jsonSaveData = JsonUtility.ToJson(GameManager.instance.saveData);

        StartCoroutine(postRequest(jsonSaveData));
    }

    public void LoadGame()
    {
        StartCoroutine(GetRequest());
    }

    public void DeleteGame()
    {
        StartCoroutine(DeleteRequest());
    }


    //Load
    IEnumerator GetRequest()
    {
        UnityWebRequest GETRequest = UnityWebRequest.Get(serviceURL + "games/game?slot="+ slot.ToString() + "&username=" + username);
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

        string loadDataJson = gamedata["saveData"];
        SaveData loadData = JsonUtility.FromJson<SaveData>(loadDataJson);

        Scene scene = loadData.playerData.scene;
        position = loadData.playerData.position;

        if (SceneManager.GetActiveScene() != scene)
        {
            SceneManager.LoadScene(scene.name);
        }

        player.transform.position = position;

    }

    //Save
    IEnumerator postRequest(string jsonSaveData)
    {
        WWWForm form = new WWWForm();

        form.AddField("autoSave", "true");
        form.AddField("difficulty", "Easy");
        form.AddField("fullScreen", "true");
        form.AddField("gameTimeInSeconds", (int) GameManager.instance.elapsedTime);
        form.AddField("gammaLvl", 6);
        form.AddField("musicEnabled", "true");
        form.AddField("musicLvl", 100);
        form.AddField("saveData", jsonSaveData);
        form.AddField("saveSlotstr", slot.ToString());
        form.AddField("sfxEnabled", "true");
        form.AddField("sfxLvl", 100);
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
