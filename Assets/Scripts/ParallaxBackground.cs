using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	private GameObject player;
	private float speed;
	public float relativeSpeed = 1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		speed = player.GetComponent<Player> ().movementSpeed - relativeSpeed;
	}

	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag ("Player");
		if (Player.isAlive) {
			speed = player.GetComponent<Player> ().movementSpeed - relativeSpeed;
			transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
		}
		if (!Player.isAlive) {
			speed = 0;
		}
	}
}
