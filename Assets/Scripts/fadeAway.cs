using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeAway : MonoBehaviour {
	private float alpha = 1f;
	public float fadingSpeed = 0.02f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alpha);
		alpha = alpha - fadingSpeed;
		if (alpha < 0f) {
			Destroy (this.gameObject);
		}
	}
}
