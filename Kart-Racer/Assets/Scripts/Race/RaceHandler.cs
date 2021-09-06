using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RaceHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject start;
    public List<GameObject> checkpoints = new List<GameObject>();
    public int currentCheckpoint = 1;
    
    public void NextCheckpoint()
    {
        currentCheckpoint++;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("check");
        if (other.gameObject.name == checkpoints[currentCheckpoint].name)
        {
            NextCheckpoint();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("yoo");
    }
}
