using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public BoxCollider col;

    public RaceHandler raceHandler;

    public Timer timer;

    // Start is called before the first frame update
    
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint") raceHandler.Collision(other.gameObject.name);
        if (other.gameObject.tag == "OutOfBounds") {timer.AddPenalty(2);}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
