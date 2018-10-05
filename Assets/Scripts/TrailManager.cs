using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour {



	GameObject player;
	public bool isPlayer = false;


	void Start(){
		player = GameObject.FindWithTag ("Player");
	}

	void Update(){
		if (breathingTest.goodBreath) {
			GetComponent<TrailRenderer> ().enabled = !isPlayer;
		} else {
			GetComponent<TrailRenderer> ().enabled = isPlayer;
		}
	}


}
