using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public static float timeLeft = 0;
    public static bool timerIsOn = false;

    public static Dictionary<int, float> quartersTime = new Dictionary<int, float>();

    public TextMeshProUGUI timeText;

    //Lambda function StartTimer() wich sets the timerIsOn to true
    public static void StartTimer()
    {
        timerIsOn = true;
    }

    public static void StopTimer()
    {
        timerIsOn = false;
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

    public static void RegisterQuarterFinished(int quarter)
    {
        quartersTime.Add(quarter, timeLeft);
    }

    public static string GetQuarterTime(int quarter)
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds(quarter == 1 ? quartersTime[quarter] : quartersTime[quarter] - quartersTime[quarter - 1]);
        string qTime = time.ToString(@"mm\:ss\:fff");
        return qTime;
    }

    void Update()
    {
        if (timerIsOn)
        {
            timeLeft += Time.deltaTime;
            System.TimeSpan time = System.TimeSpan.FromSeconds(timeLeft);
            timeText.text = time.ToString(@"mm\:ss\:fff");
            // if (timeLeft <= 0)
            // {
            //     timerIsOn = false;
            //     timeText.text = "Time's up!";
            //     ResetTextData();
            // } else if (timeLeft <= 10)
            // {
            //     RedText();
            // }
        }
    }

}
