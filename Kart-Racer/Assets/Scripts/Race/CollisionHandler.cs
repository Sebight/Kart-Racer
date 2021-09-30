using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public BoxCollider col;

    public RaceHandler raceHandler;

    // Start is called before the first frame update
    
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        raceHandler.Collision(other.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
