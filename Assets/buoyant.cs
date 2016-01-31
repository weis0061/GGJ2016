using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class buoyant : MonoBehaviour {

	public float WaterHeight;
	public float Buoyancy = 1;
	public float Torque= 100; 
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (transform.position.y < WaterHeight)
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
}
