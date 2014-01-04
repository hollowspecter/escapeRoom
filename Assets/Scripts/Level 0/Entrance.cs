using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	void OnMouseDown () {
		if (!CursorIngame.getHide())
		{
			if (IntroLevel.getID()==6) {
				IntroLevel.nextEvent();
			}
		}
	}
}
