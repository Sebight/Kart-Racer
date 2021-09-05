using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public GameObject car;
    public Rigidbody rb;

    public int turnSpeed;
    public int drivingSpeed;
    public float gravity = -9.81f;

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * drivingSpeed);
        } else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -drivingSpeed);
        }
        Vector3 localVelo = transform.InverseTransformDirection(rb.velocity);
        localVelo.x = 0;
        rb.velocity = transform.TransformDirection(localVelo);
    }

    public void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed);
        } else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed);
        }

        
    }

    public void Gravity()
    {
        rb.AddRelativeForce(Vector3.up * gravity);
    }

    // Start is called before the first frame update
    void Start()
    {
        car = gameObject;

        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //obj.transform.position = gameObject.transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Move();
        Turn();
        Gravity();
        
    }
}
