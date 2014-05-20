using UnityEngine;
using System.Collections;

public class destroyObjects : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "gameBoundary")
		{
			return;
		}

		if (other.tag == "bullet") 
		{
			Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			Destroy (gameObject); //destroys asteroid
			Destroy (other.gameObject); //destroys bullet
		}
		
		if (other.tag == "ship") 
		{
			GameObject ship = GameObject.Find("ship");
			ShipBehavior shipbehavior = ship.GetComponent<ShipBehavior>();
			shipbehavior.lives--;
			Destroy (gameObject); //destroys asteroid
			Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			if(shipbehavior.lives <= 0) {
				Destroy (other.gameObject); //destroys ship
				Application.LoadLevel(2);
			}
			//Screen.showCursor = true;
		}
	}
}