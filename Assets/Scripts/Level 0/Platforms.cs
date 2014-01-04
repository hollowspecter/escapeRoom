using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {

	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

 	public void appear()
	{
		anim.SetBool("Appear",true);
	}

	void nextEvent()
	{
		//2
		IntroLevel.nextEvent();
	}
}
