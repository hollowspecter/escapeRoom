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
	private bool isEmpty;

	// Use this for initialization
	void Start ()
	{
		position.x = Screen.width/4;
		position.y = Screen.height - scale.y - 10;

		isDone = false;
		isClosed = true;

		textQueue = new Queue();
	}

	void Update()
	{
		isEmpty = (textQueue.Count == 0);

		if ((Input.GetKeyDown(KeyCode.Space)
		     || Input.GetKeyDown(KeyCode.Return))
		     && isDone)
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
			CursorChanger.setHide(true);
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
		isClosed = true;
		isDone = false;
		CursorChanger.setHide(false);
	}

	public void showText(string text)
	{
		textQueue.Enqueue(text);
	}

	public bool queueIsEmpty()
	{
		return isEmpty;
	}
}
