using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationPopup : MonoBehaviour {

	public float alpha = 0f;
	public static bool triggered = false;
	private int goodBreaths = 0;
	public Color tmp;
	// Use this for initialization
	void Start () {
		triggered = false;
		tmp = gameObject.GetComponent<SpriteRenderer> ().color;
		tmp.a = alpha;
		gameObject.GetComponent<SpriteRenderer> ().color = tmp;
	}

	// Update is called once per frame
	void Update () {
		int newGoodbreaths = breathingTest.goodBreathCount;
		if (newGoodbreaths >= goodBreaths + 5 && !triggered) {
			goodBreaths = newGoodbreaths;
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



	}
}
