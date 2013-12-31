using UnityEngine;
using System.Collections;

public class AnimatedText : MonoBehaviour {

	public Vector2 scale;
	public Vector2 offset;

	private string str;
	private Vector2 position;
	// is true when string is written down completely
	private bool isDone;
	// is true when player "submits" to close the dialog
	private bool isClosed;
	private Queue textQueue;

	// Use this for initialization
	void Start ()
	{
		position.x = Screen.width/4;
		position.y = Screen.height - scale.y - 10;

		isDone = false;
		isClosed = true;

		textQueue = new Queue();
		textQueue.Enqueue("First text, dam dam");
		textQueue.Enqueue("Second text, works fine!");
	}

	void Update()
	{
		if (Input.anyKeyDown && isDone)
		{
			close ();
		}

		if (textQueue.Count > 0 && isClosed)
		{
			string current = (string) textQueue.Dequeue();
			StartCoroutine(AnimateText(current));
		}
	}

	void OnGUI()
	{
		if (!isClosed)
			GUI.Box(new Rect(position.x + offset.x, position.y + offset.y, scale.x, scale.y), str);
	}

	IEnumerator AnimateText(string strComplete)
	{
		if (!isDone)
		{
			isClosed = false;
			isDone = false;
			audio.Play();
			int i=0;
			str = "";
			while(i < strComplete.Length)
			{
				str += strComplete[i++];
				yield return new WaitForSeconds(0.1f);
			}
			audio.Stop();
			new WaitForSeconds(0.2f);
			isDone = true;
		}
	}

	private void close()
	{
		if (isDone) {
			if (Input.anyKeyDown) {
				isClosed = true;
				isDone = false;
			}
		}
	}
}
