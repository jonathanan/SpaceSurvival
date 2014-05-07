using UnityEngine;
using System.Collections;

public class destroyObjects : MonoBehaviour
{
	public GameObject explosion;
	ShipBehavior shipbehavior = GameObject.Find ("ship").GetComponent<ShipBehavior>();

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
		Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			Destroy (other.gameObject); //destroys ship
			Destroy (gameObject); //destroys asteroid
			//shipbehavior.lives--;
			Screen.showCursor = true;
			Application.LoadLevel(2);
		}
	}
}