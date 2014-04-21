using UnityEngine;
using System.Collections;

public class AstroidBehavior : MonoBehaviour {

	public float ast_direction = 0.0f;
	// Use this for initialization
	void Start () {
		ast_direction = Random.Range (-1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(Vector3.front * -7 * Time.deltaTime);

		Vector3 pos = transform.position;

		pos.x += 0.05f * ast_direction * Time.deltaTime;
		pos.y += 0.02f * ast_direction * Time.deltaTime;
		pos.z += -3f * Time.deltaTime;
		transform.position = pos;

		if (pos.z <= -15) 
		{
			pos.x = 0;
			pos.y = 0;
			pos.z = 50;

			transform.position = pos;

			ast_direction = Random.Range (-1.0f, 1.0f);
		}
	}
}
