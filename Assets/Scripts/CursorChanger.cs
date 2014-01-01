using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour {

	public Texture2D defaultCursor;
	public Texture2D handCursor;
	public static bool hide;
	public static bool hand;

	private Texture2D currentCursor;

	// Use this for initialization
	void Start () {
		Screen.showCursor= false;
		currentCursor = defaultCursor;
	}

	void Update()
	{
		if (hand)
			currentCursor = handCursor;
		else
			currentCursor = defaultCursor;
	}

	void OnGUI()
	{
		if (!hide)
		{
			Vector3 mousePos = Input.mousePosition;
			Rect pos = new Rect(mousePos.x, Screen.height - mousePos.y, currentCursor.width, currentCursor.height);
			GUI.Label(pos,currentCursor);
		}
	}

	/*
	 * Switching functions
	 */

	public static void setHand(bool b)
	{
		hand = b;
	}

	public static void setHide(bool b)
	{
		hide = b;
	}
}
