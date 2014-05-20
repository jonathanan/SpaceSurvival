using UnityEngine;
using System.Collections;

public class enemySpaceshipSpawner : MonoBehaviour
{
	public GameObject spaceship;			//enemy spaceship object
	float waitTimebetweenEnemyWaves = 10f;	//time to wait before spawning next wave of enemy ships
	float AImenuCases = 4;					//

	IEnumerator AImenu(int choice){		//had to store as this, so I could run as coroutine. Can't have wait stmts in regular fxns
		switch (choice)					//so had to use IEnumerator instead.
		{
		case 0:
			//SQUARE FORMATION
				//if( (spaceship1.Equals(null)) && (spaceship2 == null) && (spaceship3 == null) && (spaceship4 == null) 
				//&& (spaceship5 == null) && (spaceship6 == null) && (spaceship7 == null) && (spaceship8 == null) )
			Instantiate (spaceship, new Vector3 (-20, 10, 65), Quaternion.identity);	//top left
			Instantiate (spaceship, new Vector3 (0, 10, 65), Quaternion.identity); 		//top center
			Instantiate (spaceship, new Vector3 (20, 10, 65), Quaternion.identity);		//top right
			
			Instantiate (spaceship, new Vector3 (-20, 0, 65), Quaternion.identity); 	//center left
			Instantiate (spaceship, new Vector3 (20, 0, 65), Quaternion.identity); 		//center right
			
			Instantiate (spaceship, new Vector3 (-20, -10, 65), Quaternion.identity);	//bottom left
			Instantiate (spaceship, new Vector3 (0, -10, 65), Quaternion.identity); 	//bottom center
			Instantiate (spaceship, new Vector3 (20, -10, 65), Quaternion.identity);	//bottom right

			break;

		case 1:
			//RANDOM LOCATIONS
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity); //Random locations within the
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity); //40x20 game screen area.
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity); //Note: screen is larger
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity); //but this size gives a better 
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity); //look/feel for where enemy is 
			break;																										   //on screen.

		case 2:
			//RANDOM LOCATIONS w/more ships
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			Instantiate (spaceship, new Vector3 (Random.Range (-40, 40), Random.Range (-20, 20), 65),Quaternion.identity);
			break;

		case 3:
			//SPIRAL
			Instantiate (spaceship, new Vector3 (0, 15, 65),Quaternion.identity);				//These are poisitions around the spiral.
			yield return new WaitForSeconds (.5f);												//They go from the top, clockwise.
			Instantiate (spaceship, new Vector3 (7.5f, 13.5f, 65),Quaternion.identity);			
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (13.5f, 7.5f, 65),Quaternion.identity);			
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (15, 0, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (13.5f, -7.5f, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (7.5f, -13.5f, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (0, -15, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (-7.5f, -13.5f, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (-13.5f, -7.5f, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (-15, 0, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (-13.5f, 7.5f, 65),Quaternion.identity);
			yield return new WaitForSeconds (.5f);
			Instantiate (spaceship, new Vector3 (-7.5f, 13.5f, 65),Quaternion.identity);
			break;

		default:
		    break;
		}
	}

	void Start ()
	{
		StartCoroutine (SpawnWaves ()); //SpawnWaves is a coroutine because it has wait times that happen during gameplay, but shouldn't affect 
		//StartCoroutine (AImenu (0));	//other routines in game. AImenu is as well, but called from SpawnWaves, so don't need to call at start.
	}

	IEnumerator SpawnWaves ()
	{
		while (true) //continuously called from start of game
		{	
			int x = Random.Range (0,4); 	//random value from 0 - 2 (range returns 1 less than 2nd arg)
			//Debug.Log("x = " + x); 			//prints output to depug line at bottom of screen 
			if(GameObject.FindWithTag("Enemy") == null)
			{
				StartCoroutine(AImenu( x ));	//starts AImenu
			}
			yield return new WaitForSeconds (waitTimebetweenEnemyWaves); 


			/*if(x == 0){
				for(int i=0; i<8; ++i){
					Destroy (gameObject);
				}
			}
			else if(x == 1){
				for(int i=0; i<5; ++i){
					Destroy (gameObject);
				}
			}
			else if(x == 2){
				for(int i=0; i<8; ++i){
					Destroy (gameObject);
				}
			}
			else{// if(x == 1){
				for(int i=0; i<12; ++i){
					Destroy (gameObject);
				}
			}*/
		}
	}
}