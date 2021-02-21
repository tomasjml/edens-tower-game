using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SaveAndLoad : MonoBehaviour
{

    public Vector2 position;
    private readonly string serviceURL = "http://161.35.251.140:8086/";

    public SaveData CreateSaveData()
    {
        SaveData save = new SaveData();

        save.playerData.position = position;
        save.playerData.scene = SceneManager.GetActiveScene();

        return save;
    }

    public void SaveGame()
    {
        SaveData saveData = CreateSaveData();
        string jsonSaveData = JsonUtility.ToJson(saveData);

        StartCoroutine(postRequest(jsonSaveData));
    }

    IEnumerator postRequest(string jsonSaveData)
    {
        WWWForm form = new WWWForm();

        form.AddField("autoSave", "true");
        form.AddField("defense", 0);
        form.AddField("difficulty", "Easy");
        form.AddField("fullScreen", "true");
        form.AddField("gameTimeInSeconds", 0);
        form.AddField("gammaLvl", 6);
        form.AddField("luck", 0);
        form.AddField("musicEnabled", "true");
        form.AddField("musicLvl", 100);
        form.AddField("saveData", jsonSaveData);
        form.AddField("saveSlotstr", "One");
        form.AddField("sfxEnabled", "true");
        form.AddField("sfxLvl", 100);
        form.AddField("speed", 0);
        form.AddField("strength", 0);
        form.AddField("totalDeaths", 0);
        form.AddField("totalKills", 0);
        form.AddField("username", "robdom01");
        form.AddField("vitality", 0);

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


}
