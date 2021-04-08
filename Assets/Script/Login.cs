using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    private readonly string serviceURL = "http://161.35.251.140:8086/";


    public void GetUser()
    {
        string username = usernameInput.text;
        Debug.Log("Username " + username);

        StartCoroutine(GetUserRequest(username));

        GameManager.instance.user = username;
        usernameInput.text = "";
    }

    public void CreateUser(string username)
    {
        Debug.Log("Creting User: " + username);
        StartCoroutine(CreateUserRequest(username));
    }

    IEnumerator GetUserRequest(string username)
    {

        UnityWebRequest GETRequest = UnityWebRequest.Get(serviceURL + "users/user?username=" + username);
        yield return GETRequest.SendWebRequest();

        if (GETRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(GETRequest.error);
            yield break;
        }
        else if(GETRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("User Not Found");
            CreateUser(username);
            yield break;

        }
        else
        {
            Debug.Log("Data Loaded");
        }
 
    }

    IEnumerator CreateUserRequest(string username)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("email","Example@mail.com");
        form.AddField("firstName", "user");
        form.AddField("lastName", "user");
        form.AddField("password", "password");
        form.AddField("rol", "Client");
        form.AddField("username", username);

        UnityWebRequest GETRequest = UnityWebRequest.Post(serviceURL + "users/user", form);
        yield return GETRequest.SendWebRequest();

        if (GETRequest.result == UnityWebRequest.Result.ConnectionError || GETRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(GETRequest.error);
            yield break;
        }
        else
        {
            Debug.Log("User " + username + "created") ;
        }
    }
}
