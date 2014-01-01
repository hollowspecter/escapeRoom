using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject[] items;
	public GameObject highlighter;
	public Vector2 offset;

	private ArrayList itemGrid = new ArrayList();
	private static int selectedItem = -1;

	// Use this for initialization
	void Start () {
		highlighter.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (selectedItem >= 0) {
			highlighter.SetActive(true);
			highlighter.transform.position = items[selectedItem].transform.position;
		} else {
			highlighter.SetActive(false);
		}

		// deselect
		if (Input.GetMouseButtonDown(1) && !CursorIngame.getHide())
			selectedItem = -1;
	}

	public void addToInventory(int index)
	{
		items[index].SetActive(true);
		addItemToGrid(index);
		audio.Play();
	}

	private void addItemToGrid(int index)
	{
		itemGrid.Add(items[index]);
		int pos = itemGrid.IndexOf(items[index]);
		float xPos = items[index].transform.position.x;
		xPos = xPos + (20+offset.x)*pos;
		float yPos = items[index].transform.position.y;
		if (pos > 2)
		{
			yPos = yPos + (offset.y+20);
		}

		items[index].transform.position = new Vector2(xPos,yPos);
	}

	public GameObject[] getItems()
	{
		return items;
	}

	public static void setSelectedItem(int z)
	{
		selectedItem = z;
	}

	public static int getSelectedItem()
	{
		return selectedItem;
	}
}
