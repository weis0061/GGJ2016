using UnityEngine;
using System.Collections;

public class SpriteShaker : MonoBehaviour {
	public Vector3 StartPos;
	public float TimeLeft;
	// Use this for initialization
	void Start () {
		transform.position = StartPos;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = Random.onUnitSphere/50;
		offset.z = 0;
		transform.position+=offset;
		TimeLeft -= Time.deltaTime;
		if (TimeLeft <= 0) 
		{
			Destroy(this.gameObject);
		}
	}
}
