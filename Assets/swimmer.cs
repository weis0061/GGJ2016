using UnityEngine;
using System.Collections;

[RequireComponent(typeof(buoyant))]
public class swimmer : MonoBehaviour {
	Rigidbody rb;
	public float speed;
	public float Turnspeed;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddTorque (Vector3.up * Random.Range(-1f,1f)* Turnspeed * Time.deltaTime);
		rb.AddForce(transform.forward*speed*Time.deltaTime);
	}
}
