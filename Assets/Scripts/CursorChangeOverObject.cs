using UnityEngine;
using System.Collections;

public class CursorChangeOverObject : MonoBehaviour {

	void OnMouseEnter()
	{
		CursorChanger.setHand(true);
	}

	void OnMouseExit()
	{
		CursorChanger.setHand(false);
	}	
}
