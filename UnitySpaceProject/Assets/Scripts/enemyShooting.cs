using UnityEngine;
using System.Collections;

public class enemyShooting : MonoBehaviour {
	
	public Rigidbody projectile;
	float bulletSpeed = 50;
	float fireRate = 2f;
	float nextShot = 0f;
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextShot) {
			nextShot = Time.time + fireRate;
			
			Rigidbody instantiatedProjectile = Instantiate (projectile,				
			                                                transform.position,
			                                                transform.rotation)
															as Rigidbody;
			projectile.gameObject.tag = "ebullet";
			
			//make object move
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, bulletSpeed));

			//stops collisions between bullets and camera
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
		}

		
	}
}
