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
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				float randomnum = Random.Range(0f, 1f);
				if(randomnum > .05f)
				{
					float randomasteroidtype = Random.Range (0f,1f);
					if(randomasteroidtype > .67f)
					{
						Instantiate (hazard, spawnPosition, spawnRotation);
						hazard.gameObject.tag = "asteroid";
					}
					else if(randomasteroidtype > .33f)
					{
						Instantiate (hazard2, spawnPosition, spawnRotation);
						hazard2.gameObject.tag = "asteroid";
					}
					else
					{
						Instantiate (hazard3, spawnPosition, spawnRotation);
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
						Instantiate (powerupscore, spawnPosition, spawnRotation);
					}
					else if(randompowerup > .5f)
					{
						Instantiate (powerupshooting, spawnPosition, spawnRotation);
					}
					else if(randompowerup > .25f)
					{
						Instantiate (poweruptime, spawnPosition, spawnRotation);
					}
					else
					{
						Instantiate (powerupshield, spawnPosition, spawnRotation);
					}

					//powerup.gameObject.tag = "powerup";
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}