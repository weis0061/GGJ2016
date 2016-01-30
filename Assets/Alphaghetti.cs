using UnityEngine;
using System.Collections;

public class Alphaghetti : MonoBehaviour {

	public float Buoyancy=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.y<10){
			Buoy ();
		}
	}

	void Buoy(){
		GetComponent<Rigidbody>().AddForce(new Vector3(0,Buoyancy*Time.deltaTime,0));
	}
}
