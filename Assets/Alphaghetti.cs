using UnityEngine;
using System.Collections;

public class Alphaghetti : MonoBehaviour
{

    public float Buoyancy = 1;
    public float Torque= 100; 
    Rigidbody rb;
    public char MyChar;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (transform.position.y < 10)
        {
            Buoy();
        }
    }

    void Buoy()
    {

       // rb.AddForce(new Vector3(0, Buoyancy * Time.deltaTime, 0));
        if (Vector3.Dot(transform.rotation.eulerAngles, Vector3.up) >= 0)
        { }
            Vector3 TargetAngle=transform.rotation.eulerAngles;
            //TargetAngle.x=0;
            //TargetAngle = Vector3.zero;
            //Vector3 VecDiff = TargetAngle - transform.rotation.eulerAngles;
            //transform.Rotate(VecDiff * Time.deltaTime);
            //VecDiff=transform.TransformDirection(VecDiff);

            //if (TargetAngle.x < 0 )
            //{
            //    Vector3 VecDiff = new Vector3(1, 0, 0);
            //    rb.AddTorque(VecDiff * Time.deltaTime * Torque,ForceMode.Force);
            //}
            //else
            //{
            //    Vector3 VecDiff = new Vector3(-1, 0, 0);
            //    rb.AddTorque(VecDiff * Time.deltaTime * Torque, ForceMode.Force);
            //}

            if (TargetAngle.x < 90)
            {
                Vector3 VecDiff = new Vector3(1, 0, 0);
                rb.AddTorque(VecDiff * Time.deltaTime * Torque, ForceMode.Force);
            }
            else
            {
                
                Vector3 VecDiff = new Vector3(-1, 0, 0); 
                rb.AddTorque(VecDiff * Time.deltaTime * Torque, ForceMode.Force);
            }
    }
}
