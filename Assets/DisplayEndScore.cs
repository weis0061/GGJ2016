using UnityEngine;
using System.Collections;

public class DisplayEndScore : MonoBehaviour {

	GUIText gt;
	// Use this for initialization
	void Start () {
		gt = GetComponent<GUIText> ();
		gt.enabled = false;
	}
	public void Displayit(){
		gt.text = "Finish!\nWords Made: " + WordDetector.WordsMade + "\nLetters Used: " + WordDetector.LettersUsed;
		gt.enabled = true;
	}
}
