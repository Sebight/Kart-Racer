using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{

    public string LoadPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "N/A");
    }

    public void SavePlayerName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
