using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class CandleFlicker : MonoBehaviour {
	Light l;
	public float Min;
	public float Max;
	public float speed;
	// Use this for initialization
	void Start () {
		l=GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		l.intensity=Mathf.Lerp(l.intensity,Random.Range(Min,Max),speed*Time.deltaTime);
		//l.intensity+=(Random.Range(Min,Max)-Min)*speed;
	}
}
