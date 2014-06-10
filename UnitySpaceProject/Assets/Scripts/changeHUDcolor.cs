using UnityEngine;
using System.Collections;

public class changeHUDcolor : MonoBehaviour {

	public GameObject camera;

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color (0f, 1f, 0f); //green
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3();
		newPos.x = camera.transform.position.x - 14.5f;
		newPos.y = camera.transform.position.y - 7f;
		newPos.z = 0;
		transform.position = newPos;
		GameObject ship = GameObject.Find("front1");
		HUD hudBehavior = ship.GetComponent<HUD>();
		if (hudBehavior.min > 50) {
			renderer.material.color = new Color (0, 1, 0, 1); //green
		}
		else if (hudBehavior.min > 40) {
			renderer.material.color = new Color (.4f, .8f, .4f); //lighter green
		}
		else if (hudBehavior.min > 30) {
			renderer.material.color = new Color (.8f, .8f, .2f); //green/yellow
		}
		else if (hudBehavior.min > 20) {
			renderer.material.color = new Color (1f, 1f, 0f); //yellow
		}
		else if (hudBehavior.min > 10) {
			renderer.material.color = new Color (1f, .5f, 0f); //orange
		}
		else {
			renderer.material.color = new Color (1f, 0f, 0f); //red
		}
	}
}
