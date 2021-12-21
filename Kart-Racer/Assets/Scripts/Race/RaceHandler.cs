using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class RaceHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public int checkpoints;
    public int currentCheckpoint = 1;

    private bool raceStarted;

    private List<int> checkpointsFinished = new List<int>();

    public Transform carSpawn;

    public List<TextMeshProUGUI> quartersTexts;
    
    public Timer timer;

    public CarController car;

    public void NextCheckpoint()
    {
        currentCheckpoint++;
    }


    public bool CheckAllCheckpoints()
    {
        for (int i = 0; i < checkpoints; i++)
        {
            if (checkpointsFinished.Contains(i+1))
            {
                continue;
            } else 
            {
                return false;
            }
        }

        return true;
    }

    public void ResetRace()
    {
        currentCheckpoint = 1;
        checkpointsFinished.Clear();
        timer.quartersTime.Clear();

        timer.ResetTimer();
        raceStarted = false;
        
        car.transform.position = carSpawn.position;
        car.transform.rotation = carSpawn.rotation;
        car.GetComponent<Rigidbody>().velocity = Vector3.zero;

        foreach (TextMeshProUGUI text in quartersTexts)
        {
            text.text = "";
        }

    }
    public void Collision(string checkpoint)
    {
        int numberCheckpoint;
        int.TryParse(checkpoint, out numberCheckpoint);

        if (!checkpointsFinished.Contains(numberCheckpoint)) checkpointsFinished.Add(numberCheckpoint);

        
        //numbercheckpoint is always the quarter it finished, exception is when checkpoint one is quarter 4

        int currentQ = numberCheckpoint == 1 && raceStarted ? 4 : numberCheckpoint - 1;

        //If it's not 0 then edit the texts
        if (currentQ != 0 && raceStarted && !timer.isDNF && timer.timerIsOn)
        {
            timer.RegisterQuarterFinished(currentQ);
            quartersTexts[currentQ - 1].text = $"Q{currentQ}: {timer.GetQuarterTime(currentQ)}";
            quartersTexts[currentQ - 1].gameObject.SetActive(true);
        }

        if (numberCheckpoint == 1 && !raceStarted)
        {
            //Start the race
            raceStarted = true;
            timer.StartTimer();
        } else if (numberCheckpoint == 1 && raceStarted)
        {
            //Finish the race
            if (CheckAllCheckpoints())
            {
                timer.StopTimer();
                checkpointsFinished.Clear();
            } else 
            {
                timer.ShowRaceDNF();
            }
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
