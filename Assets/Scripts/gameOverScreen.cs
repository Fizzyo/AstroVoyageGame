using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player.isAlive) {
			gameObject.SetActive (true);
		}
	}
}
