using UnityEngine;
using System.Collections;

public class CursorChangeOverObject : MonoBehaviour {

	void OnMouseEnter()
	{
		CursorIngame.setHand(true);
	}

	void OnMouseExit()
	{
		CursorIngame.setHand(false);
	}	
}
