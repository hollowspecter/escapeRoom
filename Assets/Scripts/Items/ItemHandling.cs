using UnityEngine;
using System.Collections;

public class ItemHandling : MonoBehaviour {
	
	public int ID;
	public string description;
	private bool isStored;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		isStored = true;
	}

	void OnMouseDown()
	{
		if (isStored && !CursorIngame.getHide())
		{
			Inventory.setSelectedItem(ID);
		}
	}

	void OnMouseOver()
	{
		// On right click show description
		if (Input.GetMouseButtonDown(1) && !CursorIngame.getHide())
		{
			GameObject.FindWithTag("text").SendMessage("showText", description);
		}
	}

	// Update is called once per frame
	void Update () {

	}


}
