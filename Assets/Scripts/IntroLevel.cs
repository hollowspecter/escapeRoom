using UnityEngine;
using System.Collections;

public class IntroLevel : MonoBehaviour {

	private static int ID;
	private static bool next;
	private AnimatedText text;

	// Use this for initialization
	void Start () {
		ID = 0;
		text = (AnimatedText) gameObject.GetComponent("AnimatedText");
		next = true;
	}

	void Update()
	{	
		if (next)
		{
			switch(ID)
			{
			// First Event
			case 0:
				text.showText("Welcome to my Mind!");
				incrementID();
				break;
			// Second Event: Only shows up when the "next event" method
			// was called from somewhere "outside"
			case 1:
				text.showText("This is the second message!");
				incrementID();
				break;
			case 2:
			default:
				break;
			}
		}
	}

	private static void incrementID()
	{
		ID++;
		next = false;
	}

	public static void nextEvent()
	{
		next = true;
	}
}
