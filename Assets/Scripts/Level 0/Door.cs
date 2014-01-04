using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public AnimatedText text;
	public AudioClip audio_unlock;
	public AudioClip audio_open_squeak;
	public GameObject entrance;

	private Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void OnMouseDown()
	{
		if (!CursorIngame.getHide())
		{
			// no key
			if (IntroLevel.getID() == 3) {
				anim.SetBool("shake",true);
				text.showText("The door is locked.\n" +
					"\n" +
				              "I guess I need a key!");
				IntroLevel.nextEvent();
			} else

			// key achieved
			if (IntroLevel.getID() == 4)
			{
				//w/o key selected
				if (Inventory.getSelectedItem() != 0) {
					text.showText("It's locked, I should really use that key though");
				}
				// with
				else {
					audio.PlayOneShot(audio_unlock);
					IntroLevel.nextEvent();
				}
			} else

			// open unlocked door
			if (IntroLevel.getID () == 5)
			{
				audio.PlayOneShot(audio_open_squeak);
				anim.SetBool("open",true);
				entrance.SetActive(true);
				IntroLevel.nextEvent();
			} else

			if (IntroLevel.getID() == 6)
			{
				text.showText("The door is open!");
			}

			/*
			if (Inventory.getSelectedItem() == 0) {
				if (IntroLevel.getID() == 2)
					IntroLevel.nextEvent();
				else if (IntroLevel.getID() == 3) {
					audio.PlayOneShot(audio_unlock);
					IntroLevel.nextEvent();
				} else if (IntroLevel.getID() == 4) {
					audio.PlayOneShot(audio_open_squeak);
					IntroLevel.nextEvent();
				} else {
					IntroLevel.nextEvent();
				}
			} else
				text.showText("The door is locked.");*/
		}
	}

	void endShakeAnim()
	{
		anim.SetBool("shake",false);
	}
}
