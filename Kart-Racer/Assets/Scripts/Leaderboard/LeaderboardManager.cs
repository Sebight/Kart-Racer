using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;

public class Score{
    public string name;
    public int score;
}

public class LeaderboardManager : MonoBehaviour
{

    public Request request;
    public Action<string> successCallback;

    public string LoadPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "N/A");
    }

    public void SavePlayerName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }

    public void LogAllScores(string rawData)
    {
        Debug.Log(rawData);
        Debug.Log("ran");
        //Convert json into array
        // var scores = JsonUtility.FromJson<Dictionary<string, Score>>(rawData);
        var scores = JsonConvert.DeserializeObject<Dictionary<string, Score>>(rawData);
        Debug.Log(scores.Count);

        foreach (var score in scores)
        {
            Debug.Log(score.Value.name + " " + score.Value.score);
        }
    }

    public void FetchAllData()
    {
        //Print result of Request to 127.0.0.1:3000/db/get/all
        successCallback = (result) =>
        {
            LogAllScores(result);
        };
        request.GetRequest(successCallback);
        
    }


    void Start()
    {
        FetchAllData();
    }

    void Update()
    {
        
    }
}
