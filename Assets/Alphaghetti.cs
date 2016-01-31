using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Alphaghetti : MonoBehaviour
{

    public float Buoyancy = 1;
    public float Torque= 100; 
    Rigidbody rb;
    public char MyChar;
    [HideInInspector]
    public bool IsRemoved;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsRemoved = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsRemoved)
        {
            rb.AddForce(Vector3.up * Buoyancy*Time.deltaTime);
            if (transform.position.y > 50) 
                Destroy(this.gameObject);
            return;
        }
        if (transform.position.y < 10)
        {
            Buoy();
        }
    }

    void Buoy()
    {
            rb.AddForce(new Vector3(0, Buoyancy * Time.deltaTime, 0));
        if (Vector3.Dot(transform.rotation.eulerAngles, Vector3.up) >= 0)
        { }
            Vector3 TargetAngle=transform.forward;
            TargetAngle.x=90;
            
            Quaternion requiredRotation = Quaternion.FromToRotation(transform.forward, TargetAngle);
            //rb.AddTorque(requiredRotation.eulerAngles *Time.deltaTime);
            Debug.DrawRay(transform.position, transform.forward);
    }

    public void RemoveFromBowl()
    {
        gameObject.layer = 0;
        IsRemoved = true;
    }
}
