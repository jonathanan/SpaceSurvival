using UnityEngine;
using System.Collections;

public class PowerUpLife : MonoBehaviour {

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
			Destroy (gameObject); //destroys power up object
			
			GameObject ship = GameObject.Find("ship");
			ShipBehavior shipbehavior = ship.GetComponent<ShipBehavior>();
			shipbehavior.lives++;

		}
	}	
}
