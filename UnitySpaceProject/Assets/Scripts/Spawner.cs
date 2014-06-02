using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject spaceship;
	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject powerupscore;
	public GameObject powerupshield;
	public GameObject poweruptime;
	public GameObject powerupshooting;
	
	
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		int timemult = (int)(Time.time/60);
		Debug.Log (timemult);
		spawnWait = spawnWait - (float)timemult/100f;
		hazardCount = hazardCount + timemult*20;
		float powerupchance = 25.0f / hazardCount;
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				float randomnum = Random.Range(0f, 1f);
				if(randomnum > powerupchance)
				{
					float randomasteroidtype = Random.Range (0f,1f);
					if(randomasteroidtype > .67f)
					{
						Instantiate (hazard, spawnPosition, Quaternion.identity);
						hazard.gameObject.tag = "asteroid";
					}
					else if(randomasteroidtype > .33f)
					{
						Instantiate (hazard2, spawnPosition, Quaternion.identity);
						hazard2.gameObject.tag = "asteroid";
					}
					else
					{
						Instantiate (hazard3, spawnPosition, Quaternion.identity);
						hazard3.gameObject.tag = "asteroid";
					}
					
					
				}
				//else if(randomnum > .05f)
				//{
				//Instantiate (spaceship, spawnPosition, spawnRotation);
				//spaceship.gameObject.tag = "enemyspaceship";
				//}
				else
				{
					float randompowerup = Random.Range(0f, 1f);
					if(randompowerup > .75f)
					{
						Instantiate (powerupscore, spawnPosition, Quaternion.identity);
					}
					else if(randompowerup > .5f)
					{
						Instantiate (powerupshooting, spawnPosition, Quaternion.identity);
					}
					else if(randompowerup > .25f)
					{
						Instantiate (poweruptime, spawnPosition, Quaternion.identity);
					}
					else
					{
						Instantiate (powerupshield, spawnPosition, Quaternion.identity);
					}
					
					//powerup.gameObject.tag = "powerup";
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}