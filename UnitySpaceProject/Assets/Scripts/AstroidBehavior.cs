using UnityEngine;
using System.Collections;

public class AstroidBehavior : MonoBehaviour {
	public GameObject asteroid;
	public float ast_direction = 0.0f;
	// Use this for initialization
	void Start () {
		ast_direction = Random.Range (-0.7f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(Vector3.front * -7 * Time.deltaTime);
		
		Vector3 pos = transform.position;
		
		pos.x += 0.05f * ast_direction * Time.deltaTime;
		pos.y += 0.02f * ast_direction * Time.deltaTime;
		
		if (pos.z >= 20) 
		{
			pos.z += -7f * Time.deltaTime;
		}
		else
		{
			pos.z += -3f * Time.deltaTime;
		}
		
		transform.position = pos;
		
		if (pos.z <= -15) 
		{
			Destroy (gameObject);
		}
	}
}