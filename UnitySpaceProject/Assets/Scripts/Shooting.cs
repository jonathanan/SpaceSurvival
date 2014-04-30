﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Rigidbody projectile;
	public float bulletSpeed = 500;
	public float fireRate = 0.5f;
	public float nextShot = 0.0f;

	// Update is called once per frame
	void Update () {
		/*
		 *GetButtonDown uses the button menu in Edit>Project Settings>Input>"Fire 1"
		 *This requires the button to be pressed AND released to fire a shot.
		 *Previously used GetKey(KeyCode.F), which mapped F to firing, but continuously shot
		 *and caused bullet spray.
		 *Also limits number of shots allowed each second.
		 */
		if (Input.GetButtonDown ("Fire1") && Time.time > nextShot) {

			nextShot = Time.time + fireRate;

			Rigidbody instantiatedProjectile = Instantiate (projectile,				
			                                                transform.position,
			                                                transform.rotation)
															as Rigidbody;
			projectile.gameObject.tag = "bullet";

			//make object move
			instantiatedProjectile.velocity = transform.InverseTransformDirection(new Vector3(0, 0, bulletSpeed));

			//stops collisions between bullets and camera
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
		}
	
	}
}
