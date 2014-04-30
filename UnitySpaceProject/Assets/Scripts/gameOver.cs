using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	//---------------Play Again/Quit Game---------------------
	public bool isQuit = false;
	
	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() {
		if(isQuit) {
			Application.Quit();
		}
		else {
			Application.LoadLevel(1);
		}
	}

	//----------------------Display Score-------------------------------
	Score sscript = GameObject.Find("Score").GetComponent<Score>();
	//float finalScore = sscript.score;
	void OnGUI() {
		GUI.skin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect (625, 200, 250, 150), "TEST");
	}
}
