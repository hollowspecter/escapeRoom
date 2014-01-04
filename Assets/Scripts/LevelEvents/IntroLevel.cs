using UnityEngine;
using System.Collections;

public class IntroLevel : MonoBehaviour {

	public Inventory inventory;
	public AudioClip audio_footsteps;

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
				text.showText("Welcome to my Mind!\n" +
					"What a beautiful scene. It's gorgeous, and it always was.\n" +
					"Everything has its ups and downs, but overall this makes\n" +
					"me quite happy.");
				text.showText("That's weird.\n" +
					"I know that door always existed. But I never managed to peek\n" +
					"through it. It has always been locked. Why does it get bigger\n" +
					"like this? Shall I enter it? Or is it just me getting\n" +
				    "more aware of it... I wonder.");
				incrementID();
				break;
			// Second Event: Only shows up when the "next event" method
			// was called from somewhere "outside"
			case 1:
				inventory.addToInventory(0);
				text.showText("Funny, I just realised that I have a golden key in my\n" +
					"pocket.");
				text.showText("That means......");
				incrementID();
				break;
			case 2:
				text.showText("This door has always been there, and I've never even dared\n" +
				              "a peek. I guess I can give it a try.");
				incrementID();
				break;
			case 3:
				text.showText("Okay, it is unlocked.");
				incrementID ();
				break;
			case 4:
				text.showText("*Peeks into the door*\n" +
					"It's dark. I can barely see a thing!\n" +
					"\n" +
					"HELLO?! ANYBODY?\n" +
				              "mh");
				incrementID ();
				break;
			case 5:
				text.showText("I know this is risky, but I feel like I have to go inside\n" +
				              "to find out what really is behind that door.");
				incrementID();
				break;
			case 6:
				audio.PlayOneShot(audio_footsteps);
				Camera.main.SendMessage("fadeOut");
				StartCoroutine(loadNextLevel());
				incrementID ();
				break;
			default:
				break;
			}
		}
	}

	private IEnumerator loadNextLevel()
	{
		yield return new WaitForSeconds(audio_footsteps.length);
		Application.LoadLevel (1);
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
