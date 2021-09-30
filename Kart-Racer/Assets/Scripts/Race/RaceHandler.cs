using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RaceHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject start;
    public int checkpoints;
    public int currentCheckpoint = 1;

    private bool raceStarted;

    private List<int> checkpointsFinished = new List<int>();
    
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

    public void Collision(string checkpoint)
    {
        int numberCheckpoint;
        int.TryParse(checkpoint, out numberCheckpoint);

        if (!checkpointsFinished.Contains(numberCheckpoint)) checkpointsFinished.Add(numberCheckpoint);

        if (numberCheckpoint == 1 && !raceStarted)
        {
            //Start the race
            Debug.Log("Start");
            raceStarted = true;
        } else if (numberCheckpoint == 1 && raceStarted)
        {
            //Finish the race
            if (CheckAllCheckpoints())
            {
                Debug.Log("Finish the race");
                checkpointsFinished.Clear();
            } else 
            {
                Debug.Log("Cheater");
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
