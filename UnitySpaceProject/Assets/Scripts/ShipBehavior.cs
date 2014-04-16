using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translationH = Input.GetAxis ("Horizontal") * speed;
		float translationV = Input.GetAxis ("Vertical") * speed;
		float rotationV = Input.GetAxis ("Vertical") * rotationSpeed;
		float rotationH = Input.GetAxis ("Horizontal") * rotationSpeed;
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		translationH *= Time.deltaTime;
		translationV *= Time.deltaTime;
		rotationH *= Time.deltaTime;
		rotationV *= Time.deltaTime;

		//move ship
		transform.Translate (0, translationV, translationH);
		transform.Rotate (rotationH, 0, rotationV);
	}
}
