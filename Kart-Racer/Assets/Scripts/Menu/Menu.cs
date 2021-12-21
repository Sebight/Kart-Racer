using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Menu : MonoBehaviour
{

    public GameObject startButton;

    public GameObject timerInterface;

    public GameObject menuUI;

    public Camera mainMenuCamera;

    public GameObject returnToMainMenuPopup;

    public GameObject leaderboardTab;

    public GameObject leaderboardNamePopup;

    public GameObject leaderboardListTab;

    public GameObject leaderboardNameInput;

    private bool returnMenuVisible = false;

    public RaceHandler raceHandler;

    public LeaderboardManager leaderboardManager;

    public TextMeshProUGUI playerNameText;

    public void StartGame()
    {
        //Disable menuUI and enable timerInterface and disable mainMenuCamera
        menuUI.SetActive(false);
        timerInterface.SetActive(true);
        mainMenuCamera.enabled = false;

        raceHandler.ResetRace();
    }

    public void ReturnToMenu()
    {
        //Enable menuUI and disable timerInterface and enable mainMenuCamera
        menuUI.SetActive(true);
        returnMenuVisible = false;
        returnToMainMenuPopup.SetActive(false);
        Time.timeScale = 1;
        timerInterface.SetActive(false);
        mainMenuCamera.enabled = true;
    }

    public void OpenLeaderboard()
    {
        leaderboardTab.SetActive(true);
        if (leaderboardManager.LoadPlayerName() != "N/A")
        {
            leaderboardListTab.SetActive(true);
        }
        else
        {
            leaderboardNamePopup.SetActive(true);
        }
    }

    public void UpdateNameText()
    {
        playerNameText.text = "Logged in as: " + leaderboardManager.LoadPlayerName();
    }


    public void ApplyName()
    {
        leaderboardManager.SavePlayerName(leaderboardNameInput.GetComponent<TMP_InputField>().text);
        leaderboardNamePopup.SetActive(false);
        UpdateNameText();
    }

    void Start()
    {
        UpdateNameText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            returnMenuVisible = !returnMenuVisible;
            Time.timeScale = returnMenuVisible ? 0 : 1;
            returnToMainMenuPopup.SetActive(returnMenuVisible);
        }
    }
}
