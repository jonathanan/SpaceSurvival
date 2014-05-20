using UnityEngine;
using System.Collections;

public class PowerUpSlowTime : MonoBehaviour {

	ShipBehavior shipbehavior = GameObject.Find ("ship").GetComponent<ShipBehavior>();

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "gameBoundary")
		{
			return;
		}
		
		if (other.tag == "bullet") 
		{
			return;
		}
		
		if (other.tag == "ship") 
		{
			//Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			//Destroy (other.gameObject); //destroys ship
			Destroy (gameObject); //destroys power up object

			GameObject ship = GameObject.Find("ship");
			ShipBehavior ship2 = ship.GetComponent<ShipBehavior>();
			ship2.SlowTime = true;
			ship2.SlowTimeTime = Time.time + 30f;
			//other.gameObject.trans
		}
	}
}
