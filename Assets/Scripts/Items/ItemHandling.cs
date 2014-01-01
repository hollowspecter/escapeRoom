using UnityEngine;
using System.Collections;

public class ItemHandling : MonoBehaviour {
	
	public int ID;
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

	// Update is called once per frame
	void Update () {

	}


}
