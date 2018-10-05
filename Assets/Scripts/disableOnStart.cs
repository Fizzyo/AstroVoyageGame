using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
		Image img = gameObject.GetComponent<Image> ();
		img.enabled = false;

	}

	void Update(){
		if (Player.isAlive == false) {
			Image img = gameObject.GetComponent<Image> ();
			img.enabled = true;
			foreach (Transform child in transform) {
				child.gameObject.SetActive (true);
			}
		}
	}
}
