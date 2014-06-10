using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool isPause = false;
	private Rect windowRect = new Rect(400f, 175f, 500f, Screen.height/3);
	GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPause = !isPause;
			if(isPause == true)
			{
				Time.timeScale = 0;
				player = GameObject.FindWithTag("ship");
				player.transform.GetComponent<ShipBehavior>().enabled = false;
				OnGUI();
			}
			else
			{
				Time.timeScale = 1;
				player = GameObject.FindWithTag("ship");
				player.transform.GetComponent<ShipBehavior>().enabled = true;
			}
		}
	}

	void OnGUI() {
		if (isPause) {
			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DrawButtons, "Game Paused:");
		}
	}

	private void DrawButtons(int windowID)
	{
		GUILayout.BeginVertical();
		GUILayout.Space (25);
		if (GUILayout.Button ("Resume")) {
			isPause = false;
			Time.timeScale = 1;
			player = GameObject.FindWithTag("ship");
			player.transform.GetComponent<ShipBehavior>().enabled = true;
		}
		GUILayout.Space (25);
		if (GUILayout.Button ("Restart")) {
			Application.LoadLevel(1);
			isPause = false;
			Time.timeScale = 1;
			player = GameObject.FindWithTag("ship");
			player.transform.GetComponent<ShipBehavior>().enabled = true;
		}
		GUILayout.Space (25);
		if (GUILayout.Button ("Quit")) {
			Application.Quit();
		}
		GUILayout.Space (25);
		GUILayout.EndVertical();
	}
}
