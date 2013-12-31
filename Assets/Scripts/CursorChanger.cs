using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour {

	public Texture2D defaultCursor;
	public Texture2D handCursor;

	private Texture2D currentCursor;

	// Use this for initialization
	void Start () {
		Screen.showCursor= false;
		currentCursor = defaultCursor;
	}
	
	void OnGUI()
	{
		Vector3 mousePos = Input.mousePosition;
		Rect pos = new Rect(mousePos.x, Screen.height - mousePos.y, currentCursor.width, currentCursor.height);
		GUI.Label(pos,currentCursor);
	}

	/*
	 * Switching functions
	 */

	public void switchToHand()
	{
		currentCursor = handCursor;
	}

	public void switchToDefault()
	{
		currentCursor = defaultCursor;
	}
}
