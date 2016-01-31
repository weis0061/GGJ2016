using UnityEngine;
using System.Collections;

public class AddThings : MonoBehaviour {
	public Transform SpawnMarker;
	[System.Serializable]
	public struct SpawnChannel{
		public GameObject gameObject;
		public float Timer;
		[HideInInspector]
		public float TimeLeft;
	}
	public SpawnChannel[] SpawnChannels;
	// Use this for initialization
	void Start () {
		for(int i=0;i<SpawnChannels.Length;++i){
			SpawnChannels[i].TimeLeft=SpawnChannels[i].Timer;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<SpawnChannels.Length;++i){
			SpawnChannels[i].TimeLeft-=Time.deltaTime;
			if(SpawnChannels[i].TimeLeft<-0f){
				GameObject.Instantiate(SpawnChannels[i].gameObject,SpawnMarker.position,new Quaternion(90,0,0,0));
				SpawnChannels[i].TimeLeft=SpawnChannels[i].Timer;
			}
		}
	}
}
