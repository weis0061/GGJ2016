using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
	public AudioClip[] RandomClips;

	public void play(){
		int i=Random.Range(0,RandomClips.Length-1);
		GetComponent<AudioSource>().clip=RandomClips[i];
		GetComponent<AudioSource>().Play();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
