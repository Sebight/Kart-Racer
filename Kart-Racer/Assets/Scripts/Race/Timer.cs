using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeLeft = 0;
    public bool timerIsOn = false;

    public Dictionary<int, float> quartersTime = new Dictionary<int, float>();

    public bool isDNF = false;

    public TextMeshProUGUI timeText;

    //Lambda function StartTimer() wich sets the timerIsOn to true
    public void StartTimer()
    {
        timerIsOn = true;
    }

    public void AddPenalty(int n)
    {
        timeLeft += n;
    }

    public void StopTimer()
    {
        timerIsOn = false;
    }

    public void ResetTimer()
    {
        timerIsOn = false;
        timeLeft = 0;
        timeText.text = "00:00:000";
        timeText.color = Color.white;
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

    public void RegisterQuarterFinished(int quarter)
    {
        quartersTime.Add(quarter, timeLeft);
    }

    public string GetQuarterTime(int quarter)
    {
        if (!isDNF)
        {
            try
            {
                System.TimeSpan time = System.TimeSpan.FromSeconds(quarter == 1 ? quartersTime[quarter] : quartersTime[quarter] - quartersTime[quarter - 1]);
                string qTime = time.ToString(@"mm\:ss\:fff");
                return qTime;
            }
            catch
            {
                ShowRaceDNF();
                return "skipped";
            }
        }
        return "";

    }

    public void ShowRaceDNF()
    {
        isDNF = true;
        StopTimer();
        RedText();
        timeText.text = "DNF";
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
