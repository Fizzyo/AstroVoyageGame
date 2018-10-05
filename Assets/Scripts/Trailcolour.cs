using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColour : MonoBehaviour {

	GameObject player;


	void Start(){
		player = GameObject.FindWithTag ("Player");
	}

	void Update(){
		if (breathingTest.goodBreath) {
			GetComponent<TrailRenderer> ().enabled = true;
		} else {
			GetComponent<TrailRenderer> ().enabled = false;
		}
	}

}