using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject spaceship;
	public GameObject hazard;
	public GameObject powerup;

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
				if(Random.Range (0f, 1f) > .15f)
				{
					Instantiate (hazard, spawnPosition, spawnRotation);
					hazard.gameObject.tag = "asteroid";
				}
				else if(Random.Range (0f, 1f) < .67f)
				{
					Instantiate (spaceship, spawnPosition, spawnRotation);
					//spaceship.gameObject.tag = "enemyspaceship";
				}
				else
				{
					Instantiate (powerup, spawnPosition, spawnRotation);
					//powerup.gameObject.tag = "powerup";
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}