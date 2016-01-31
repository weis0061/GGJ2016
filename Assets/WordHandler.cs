using UnityEngine;
using System.Collections;

public class WordHandler : MonoBehaviour {

	public WordDetector wd;
	public Transform SpawnMarker;
	public GameObject DuckPrefab;
	public GameObject VoodooPrefab;
	public GameObject TomatoPrefab;
	public GameObject DemonPrefab;

	public SoundPlayer PlayOnWord;
	public SoundPlayer PlayOnDemon;
	void Start(){
		if(!wd)wd=GetComponent<WordDetector>();
		if(!SpawnMarker)SpawnMarker=wd.PutPastaPosition;
	}
	public void HandleWord(string w){
		switch(w){
		default:PlayOnWord.play ();break;
		case "noodles":wd.AddPastas(20);break;/*
		case "duck":GameObject.Instantiate(DuckPrefab,SpawnMarker.position,SpawnMarker.rotation);break;
		case "demon":PlayOnDemon.play();GameObject.Instantiate(DemonPrefab,SpawnMarker.position,SpawnMarker.rotation);break;
		case "satan":PlayOnDemon.play();GameObject.Instantiate(DemonPrefab,SpawnMarker.position,SpawnMarker.rotation);break;
		case "voodoo":GameObject.Instantiate(VoodooPrefab,SpawnMarker.position,SpawnMarker.rotation);break;
		case "tomato":GameObject.Instantiate(TomatoPrefab,SpawnMarker.position,SpawnMarker.rotation);break;*/
		}
	}
}
