using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed;
	public float maxRotateAngleX = 7f;
	public float maxRotateAngleZ = 2f;
	Vector3 curRot;
	float maxRotX; float minRotX;
	float maxRotZ; float minRotZ;

	void Start() {
		//Need this because for some reason Rotate x starts at -8
		transform.Rotate (0,0,0);
		//Get initial rotation
		curRot = this.transform.eulerAngles;
		//calculate limit angles
		maxRotX = curRot.x + maxRotateAngleX;
		minRotX = curRot.x - maxRotateAngleX;
		maxRotZ = curRot.z + maxRotateAngleZ;
		minRotZ = curRot.z;
	}
	
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

		//translate boundaries
		float minTransX = -15F; float maxTransX = 15F;
		float minTransY = -8.3F; float maxTransY = 7.0F;
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + translationH, minTransX, maxTransX);
		pos.y = Mathf.Clamp (pos.y + translationV, minTransY, maxTransY);
		pos.z = 0;
		//move ship
		transform.position = pos;

		//rotation boundaries
		//limit rotations
		curRot.x += rotationH;
		curRot.z += rotationV;
		curRot.x = Mathf.Clamp (curRot.x, minRotX, maxRotX);
		curRot.z = Mathf.Clamp (curRot.z, minRotZ, maxRotZ);
		//rotate ship
		this.transform.eulerAngles = curRot;
	}
}
