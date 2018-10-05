using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSetupWarning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (MainMenu.canPlayGame) {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (MainMenu.canPlayGame) {
			gameObject.SetActive (false);
		}
	}
}
