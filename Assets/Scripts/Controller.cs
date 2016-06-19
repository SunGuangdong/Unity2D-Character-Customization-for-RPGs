using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A))
			transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
		else if (Input.GetKey (KeyCode.D))
			transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
	
	}
}
