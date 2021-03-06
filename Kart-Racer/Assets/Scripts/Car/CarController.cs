using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public enum Direction
    {
        Forward,
        Backward
    }

    public GameObject car;
    public Rigidbody rb;

    public int turnSpeed;
    public int drivingSpeed;
    public float gravity = -9.81f;

    public Queue<Transform> lastPositions = new Queue<Transform>();

    public float lastReturnTime;
    public float lastRecordTime;

    public Vector3 startPos;
    public Quaternion startRot;

    public Direction direction;



    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * drivingSpeed);
            direction = Direction.Forward;
            //rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * drivingSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * -drivingSpeed);
            direction = Direction.Backward;
            // rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -drivingSpeed);
        }
        Vector3 localVelo = transform.InverseTransformDirection(rb.velocity);
        localVelo.x = 0;
        rb.velocity = transform.TransformDirection(localVelo);
    }

    public void Turn()
    {
        //Reverse steering when in reverse
        // bool reverse = direction == Direction.Backward ? true : false;
        bool reverse = false;

        if (Input.GetKey(KeyCode.D))
        {
            int turn = reverse ? -turnSpeed : turnSpeed;
            rb.AddTorque(Vector3.up * turn);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            int turn = reverse ? turnSpeed : -turnSpeed;
            rb.AddTorque(Vector3.up * turn);
        }


    }

    public bool IsOffTheTrack()
    {
        //Draw ray from the car down to the ground
        Ray ray = new Ray(car.transform.position, car.transform.up);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3.5f))
        {
            if (hit.collider.gameObject.name == "OffTrack")
            {
                return true;
            }
        }
        return false;
    }
    public bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, (-transform.up * 5));
        if (Physics.Raycast(ray, 5))
        {
            /*if (lastRecordTime + 2 <= Time.time)
                //if (lastPositions.Count == 5) lastPositions.Dequeue();
                lastPositions.Enqueue(transform);
            Debug.Log(lastPositions.Count + " "+ transform.position);*/
            return true;
        }
        else
        {
            /*if (lastReturnTime + 2 <= Time.time)
            {
                Transform pos = lastPositions.Dequeue();
                transform.position = new Vector3(0, 0, 0);//pos.position;
                transform.rotation = pos.rotation;
                Debug.Log("back. Returned to: "+pos.transform.position);
                lastReturnTime = Time.time;
            }*/
            return false;
        }
    }

    public void Gravity()
    {
        rb.AddForce(transform.up * gravity);
    }

    // Start is called before the first frame update
    void Start()
    {
        car = gameObject;
        startPos = transform.position;
        startRot = transform.rotation;
        // startPos.y = 8.821599f;
        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //obj.transform.position = gameObject.transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGrounded())
        {
            Move();
            Turn();
            //IsOffTheTrack();
        }
        Gravity();

    }
}
