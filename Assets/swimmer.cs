using UnityEngine;
using System.Collections;

[RequireComponent(typeof(buoyant))]
public class swimmer : MonoBehaviour {
	Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(-transform.right+transform.forward*speed*Time.deltaTime);
	}
}
