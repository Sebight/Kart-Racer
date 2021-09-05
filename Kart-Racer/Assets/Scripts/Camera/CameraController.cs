using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform car;
    public float smoothing;
    public float rotationSmoothing;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = new Vector3(transform.forward.x*15, offset.y, offset.z);
        transform.position = Vector3.Lerp(transform.position, car.position - transform.forward*10 - new Vector3(0, -2, 0), smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, car.rotation, rotationSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(5, transform.rotation.eulerAngles.y, 0));
    }
}
