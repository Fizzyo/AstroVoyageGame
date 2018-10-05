using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeTextAway : MonoBehaviour {
	private float alpha = 1f;
	public float fadingSpeed = 0.02f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<TMPro.TextMeshProUGUI> ().color = new Color (1, 1, 1, alpha);
		alpha = alpha - fadingSpeed;
		if (alpha < 0f) {
			alpha = 1f;
			gameObject.SetActive (false);
		}
	}
}
