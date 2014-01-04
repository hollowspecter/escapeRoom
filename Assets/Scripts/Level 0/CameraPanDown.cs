using UnityEngine;
using System.Collections;

public class CameraPanDown : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0,6,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 0)
		{
			Vector3 movement = new Vector3(0, transform.position.y - speed * Time.deltaTime, -10);
			transform.position = movement;
		}
	}
}
