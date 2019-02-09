using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManagerEntry : MonoBehaviour {
	public UnityEngine.UI.Image img;
	public UnityEngine.UI.Text txt;

	private Coroutine removeCoroutine;

	public void CloseEntry () {
		StopCoroutine(removeCoroutine);
		
		MessageManager.Instance ().RemoveMessage (this);
	}

	//We want the coroutine to belong to this object, so that if it's
	//destroyed before timeout, the coroutine stops.
	internal void TimedRemoveMessage (float removeWait) {
		if (gameObject.activeSelf)
			removeCoroutine = StartCoroutine (RemoveMessage (removeWait));
	}

	internal IEnumerator RemoveMessage (float removeWait) {
		yield return new WaitForSeconds (removeWait);

		MessageManager.Instance ().RemoveMessage (this);
	}

	internal void SetEntry (string message, Color color, Sprite sprite) {
		if (sprite)
			img.sprite = sprite;

		txt.text = message;
		txt.color = color;
	}
}