using UnityEngine;
using System.Collections;

public class IntroLevel : MonoBehaviour {

	public Inventory inventory;
	public GameObject platforms;
	public GameObject door;
	public AudioClip audio_footsteps;

	private static int ID;
	private static bool next;
	private AnimatedText text;


	// Use this for initialization
	void Start () {
		ID = 0;
		text = (AnimatedText) gameObject.GetComponent("AnimatedText");
		next = true;
		CursorIngame.setHide(true);
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
				text.showText("But there has always been that place...\n" +
					"\n" +
					"On an island I would never reach.\n" +
					"\n" +
				              "And a door I couldn't even peek through.");

				incrementID();
				break;
			// camera pan down is done
			case 1:
				//inventory.addToInventory(0);
				platforms.SendMessage("appear");
				incrementID();
				break;
			// platforms appeared
			case 2:
				text.showText("What... just happened!?\n" +
					"\n" +
				              "Those platforms... now I can reach the house..");
				incrementID();
				break;
			// door was clicked
			case 3:
				text.showText("Oh. Apparently I had one with me all the time");
				inventory.addToInventory(0);
				incrementID();
				break;
			case 4:
				text.showText("Yes, the door is unlocked.\n" +
				              "What will lie ahead?\n" +
				              "\n" +
				              "I guess a peek doesn't hurt...");
				incrementID();
				break;
			case 5:
				text.showText("It's so dark....\n" +
					"I can barely see anything.\n" +
					"But it has a very interesting and familiar atmosphere..\n" +
				              "It's a bit scary...");
				text.showText("But I have to check it out!\n" +
					"Afterall..\n" +
					"\n" +
				              "It's a part of me.");
				incrementID();
				break;
			case 6:
				text.showText("Allright.\n" +
					"\n" +
				              "I am going in!");
				audio.PlayOneShot(audio_footsteps);
				Camera.main.SendMessage("fadeOut");
				StartCoroutine(loadNextLevel());
				incrementID();
				break;
			/*
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
				*/
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
		Debug.print("Current ID: "+ID);
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
