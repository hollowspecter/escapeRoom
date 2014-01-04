using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public Vector3 vectorToCamera = new Vector3(-0.2f, -0.15f, 9.0f);

	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ViewportToWorldPoint(vectorToCamera);
	}
}
