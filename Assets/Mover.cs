using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        mask = 1<<LayerMask.NameToLayer("grabbables") | 1<<LayerMask.NameToLayer("noodles");
        p = new Plane(new Vector3(0, 1, 0), new Vector3(0, 10, 0));
    }

    Rigidbody SelectedRb;
    Camera cam;
    int mask;
    Plane p;
    public float PullForce;

    // Update is called once per frame
    void Update()
    {
        //select the pasta
        if (Input.GetButtonDown("Select"))
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhit;
            if (Physics.Raycast(r, out rhit,mask))
            {
                SelectedRb = rhit.rigidbody;
            }
		}
		if (Input.GetButtonUp("Select"))
		{
			SelectedRb = null;
		}

        //if pasta is selected, move it
        if (Input.GetButton("Select") && SelectedRb != null)
        {
            {
                float distance = 0;
                Ray r = cam.ScreenPointToRay(Input.mousePosition);

                if (p.Raycast(r, out distance))
                {
                    Vector3 TargetPos = r.direction * distance+transform.position;
                    SelectedRb.AddForce((TargetPos - SelectedRb.transform.position) * PullForce * Time.deltaTime);
                }
            }
        }
    }

}
