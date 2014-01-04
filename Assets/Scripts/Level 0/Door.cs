using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Vector2 oldSize;
	public AnimatedText text;
	public AudioClip audio_unlock;
	public AudioClip audio_open_squeak;

	// Use this for initialization
	void Start () {
		collider2D.enabled = false;
	}
	
	void OnMouseDown()
	{
		if (!CursorIngame.getHide())
		{
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
				text.showText("The door is locked.");
		}
	}

	void activate() {
		collider2D.enabled = true;
	}

	void giveKeyEvent() {
		IntroLevel.nextEvent();
	}
}
