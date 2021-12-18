using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeLeft = 90;
    public static bool timerIsOn = false;

    public TextMeshProUGUI timeText;

    //Lambda function StartTimer() wich sets the timerIsOn to true
    public static void StartTimer()
    {
        timerIsOn = true;
    }

    private void RedText()
    {
        timeText.color = Color.red;
    }

    private void ResetTextData()
    {
        timeText.color = Color.white;
        timeText.text = " ";
    }

    void Update()
    {
        if (timerIsOn)
        {
            timeLeft -= Time.deltaTime;
            System.TimeSpan time = System.TimeSpan.FromSeconds(timeLeft);
            timeText.text = time.ToString(@"mm\:ss\:fff");
            if (timeLeft <= 0)
            {
                timerIsOn = false;
                timeText.text = "Time's up!";
                ResetTextData();
            } else if (timeLeft <= 10)
            {
                RedText();
            }
        }
    }

}
