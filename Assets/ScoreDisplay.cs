using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	GUIText gt;
	void Start(){
		gt = GetComponent<GUIText> ();
	}
	// Update is called once per frame
	void Update () {
		gt.text="Letters Used: "+WordDetector.LettersUsed+"\nWords Made: "+WordDetector.WordsMade+"\nTime Left: "+(int)WordDetector.TimeLeft+" seconds";
	}
}
