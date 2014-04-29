using UnityEngine;
using System.Collections;

public class destroyByShot : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "gameBoundary")
		{
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}