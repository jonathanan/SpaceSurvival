using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour {
	public GameObject asteroid;
	public float rotationSpeed = 0.0f;
	float ast_direction = 0.0f;
	float ast_rotation = 0.0f;
	// Use this for initialization
	void Start () {
		ast_direction = Random.Range (-0.7f, 0.7f);
		ast_rotation = Random.Range (-50f, 50f);
		rotationSpeed = Random.Range (0.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		//Translate
		Vector3 pos = transform.position;
		pos.x += 0.05f * ast_direction * Time.deltaTime;
		pos.y += 0.02f * ast_direction * Time.deltaTime;
		
		if (pos.z >= 20) 
		{
			pos.z += -7f * Time.deltaTime;
		}
		else
		{
			pos.z += -7f * Time.deltaTime;
		}
		transform.position = pos;
		//Delete once asteroid goes past camera
		if (pos.z <= -15) 
		{
			Destroy (gameObject);
		}

		//Rotate
		Vector3 rot = new Vector3();
		rot.x += ast_rotation * rotationSpeed * Time.deltaTime;
		rot.y += ast_rotation * rotationSpeed * Time.deltaTime;
		rot.z += ast_rotation * rotationSpeed * Time.deltaTime;
		transform.Rotate (rot);
	}
}