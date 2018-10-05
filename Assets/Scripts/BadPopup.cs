using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPopup : MonoBehaviour {

	public float alpha = 0f;
	private int badBreathCount = 0;
	public static bool triggered = false;
	public Color tmp;
	// Use this for initialization
	void Start () {
		tmp = gameObject.GetComponent<SpriteRenderer> ().color;
		tmp.a = alpha;
		gameObject.GetComponent<SpriteRenderer> ().color = tmp;
	}

	// Update is called once per frame
	void Update () {
		int newBadBreathCount = breathingTest.breathCount - breathingTest.goodBreathCount;
		if (newBadBreathCount > badBreathCount && !PopupManager.triggered && !triggered) {
			triggered = true;
			alpha = 1f;
			tmp = gameObject.GetComponent<SpriteRenderer> ().color;
			tmp.a = alpha;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (tmp.r, tmp.g, tmp.b, alpha);
		} else if (triggered) {
			if (alpha == 0f) {
				triggered = false;
			} else {
				alpha -= 0.01f;
				tmp = gameObject.GetComponent<SpriteRenderer> ().color;
				tmp.a = alpha;
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (tmp.r, tmp.g, tmp.b, alpha);
			}
		}
		badBreathCount = newBadBreathCount;

		if (PopupManager.triggered) {
			triggered = false;
			alpha = 0f;
			tmp = gameObject.GetComponent<SpriteRenderer> ().color;
			tmp.a = alpha;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (tmp.r, tmp.g, tmp.b, alpha);
		}

	}
}
