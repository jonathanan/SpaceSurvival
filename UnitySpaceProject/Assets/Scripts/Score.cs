using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	float score = 0;

	void Update() {
		score = Time.time;
	}

	void OnGUI() {
		GUI.skin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect(0,10,45,30), "Score:");
		GUI.Box (new Rect (50, 10, 50, 30), score.ToString ("F0"));
	}
}
