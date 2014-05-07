using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float score = 0;
	public Texture2D crosshairImage;

	void Update() {
		score = Time.time;
	}

	void OnGUI() {
		GUI.skin.box.alignment = TextAnchor.MiddleLeft;
		GUI.Box (new Rect(0,10,45,30), "Score:");
		GUI.Box (new Rect (50, 10, 50, 30), score.ToString ("F0"));
		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}
