using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManagerTest : MonoBehaviour {
	MessageManager messageManager;
	[SerializeField] private string[] randomThoughts;

	// Use this for initialization
	void Start () {
		messageManager = MessageManager.Instance ();

		StartCoroutine (MessageManagerTestLoop ());
		StartCoroutine (InterjectRandomThoughts ());
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			messageManager.DisplayMessage ("This is a debug message. You pressed space.", Color.black, 200f, null, true);
		}
	}

	IEnumerator MessageManagerTestLoop () {
		while (true) {
			Color c = UnityEngine.Random.ColorHSV ();
			c.a = 1f;

			int removeIn = UnityEngine.Random.Range (1, 10);

			messageManager.DisplayMessage ("This message will self destruct in " + removeIn.ToString ("0") + "s", c, removeIn);

			yield return new WaitForSeconds (2f);
		}
	}

	IEnumerator InterjectRandomThoughts () {
		while (true) {
			if (randomThoughts.Length == 0)
				yield break;

			messageManager.DisplayMessage (randomThoughts[UnityEngine.Random.Range (0, randomThoughts.Length)], Color.blue, 60f, null, true);
			int delay = UnityEngine.Random.Range(5, 25);
			messageManager.DisplayMessage ("The next random thought will appear in " + delay + " seconds.", Color.cyan, 3f, null, true);
			
			yield return new WaitForSeconds (delay);
		}
	}
}