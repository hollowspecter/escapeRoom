using UnityEngine;
using System.Collections;

public class NYGJtext : MonoBehaviour {

	private AnimatedText text;
	private static int ID;
	private static bool next;

	void Start()
	{
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
			case 0:
				text.showText("Will be continued....");
				text.showText("Sorry, but this is already the end of this game.\n" +
				              "I did not make the NewYearsGameJam-Deadline, but I did come up\n" +
				              "with a cool Game Concept I want to keep working on\n" +
				              "\n" +
				              "So....");
				text.showText("Please follow me on twitter (@hollowspecter) or\n" +
				              "Stay tuned via my blog\n" +
				              "www.hollowspectder.blogspot.com\n" +
				              "For future updates on this game!");
				text.showText("This game will be starring @watacoso's art!\n" +
				              "Obviously, the current \"art\" is not his, but just some\n" +
				              "Mockup-Art I have come up with real quick");
				text.showText("I hope you enjoyed this little insight in my mind\n" +
				              "Have a wonderful year 2014!");
				text.showText("\n" +
				              "\n" +
				              "The End\n");
				incrementID();
				break;
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
	
	public static int getID()
	{
		return ID;
	}
}
