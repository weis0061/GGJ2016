using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		cam=GetComponent<Camera>();
		mask=LayerMask.NameToLayer("grabbables")|LayerMask.NameToLayer("noodles");
		p=new Plane(new Vector3(0,1,0),new Vector3(0,10,0));
	}

	Rigidbody SelectedRb;
	Camera cam;
	int mask;
	Plane p;
	public float PullForce;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//select the pasta
		if(Input.GetButtonDown("Select"))
		{
			Debug.Log("s");
			Ray r= cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit rhit;
			if(Physics.Raycast(r,out rhit,mask))
			{
				SelectedRb=rhit.rigidbody;
			}
		}

		//if pasta is selected, move it
		if(Input.GetButton("Select")&&SelectedRb!=null)
		{
			if(SelectedRb)
			{
				float distance=0;
				Ray r= cam.ScreenPointToRay(Input.mousePosition);
				
				if(p.Raycast(r,out distance))
				{
					Vector3 TargetPos=r.direction*distance;
					SelectedRb.AddForce((TargetPos-SelectedRb.transform.position)*PullForce*Time.deltaTime);
				}
			}
		}
		if(Input.GetButtonUp("Select"))
		{
			SelectedRb=null;
		}
	}
}
