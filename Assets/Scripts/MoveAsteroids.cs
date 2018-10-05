using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroids : MonoBehaviour {
	public float UpSpeed = 1f;

	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + Vector3.up * Time.deltaTime * UpSpeed;
	}
}
