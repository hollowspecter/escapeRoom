using UnityEngine;
using System.Collections;

public class House : MonoBehaviour
{
	public AnimatedText text;

	// Update is called once per frame
	void OnMouseDown()
	{
		if (!CursorIngame.getHide())
		{
			text.showText("This is a house in my mind I have never entered before.");
		}
	}
}
