using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Vector2 oldSize;

	// Use this for initialization
	void Start () {
		collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void activate() {
		collider2D.enabled = true;
	}
}
