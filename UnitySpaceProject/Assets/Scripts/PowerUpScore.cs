﻿using UnityEngine;
using System.Collections;

public class PowerUpScore : MonoBehaviour
{
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
			Destroy (gameObject); //destroys power up object
			GameObject ship = GameObject.Find("ship");
			ShipBehavior shipScript = ship.GetComponent<ShipBehavior>();
			shipScript.doBarrelRoll = true; //do barrellRoll
			GameObject score = GameObject.Find("Score");
			Score scoreScript = score.GetComponent<Score>();
			scoreScript.AddScore(250); //add 250 to score
		}
	}
}