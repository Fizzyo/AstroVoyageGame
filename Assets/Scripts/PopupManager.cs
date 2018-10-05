using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {

	public float alpha = 0f;
	public static bool triggered = false;
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
		if (breathingTest.goodBreath && !triggered) {
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
