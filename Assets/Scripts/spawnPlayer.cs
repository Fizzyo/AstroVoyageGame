using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour {
	public List<GameObject> ships = new List<GameObject>();
	// Use this for initialization
	void Awake () {
		string shiptype = PlayerPrefs.GetString ("ship", "orangeBall");
		if (shiptype.Equals ("orangeBall")) {
			Instantiate (ships [0]);
		} else if (shiptype.Equals ("greyShip")) {
			Instantiate (ships [1]);
		} else if (shiptype.Equals ("yellowShip")) {
			Instantiate (ships [2]);
		} else if (shiptype.Equals ("llama")) {
			Instantiate (ships [3]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
