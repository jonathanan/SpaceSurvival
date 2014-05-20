using UnityEngine;
using System.Collections;

public class enemyShipBehavior : MonoBehaviour {
	//public GameObject enemyShip; 	//enemy ship object
	//float enemyDir = 0.0f;			//enemy ship direction, initially set to zero (place-holder value)
	Vector3 pos;					//enemy ship position vector

	// Use this for initialization
	void Start () {
		transform.Rotate (0f, 180f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		pos = transform.position; //Translate

				//pos.x += 0.05f * enemyDir * Time.deltaTime;
				//pos.y += 0.02f * enemyDir * Time.deltaTime;

		if(pos.z > 55f)
			pos.z += -7f * Time.deltaTime; //ship flies through sky (ie: from "front" of screen to "back")

		transform.position = pos;


		/*if (pos.z <= -15) //Delete once enemy ship goes past camera
		{
			Destroy (gameObject);
		}*/
	}
}