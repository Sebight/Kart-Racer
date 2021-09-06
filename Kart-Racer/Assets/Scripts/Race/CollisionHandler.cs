using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public BoxCollider col;

    // Start is called before the first frame update
    
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("ya yeet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
