using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAsteroids : MonoBehaviour {

    public int min = -5;
    public int max = 5;
    private int rotationSpeed;
	private GameObject asteroid;
	// Use this for initialization
	void Start () {
        rotationSpeed = Random.Range (min,max);
		asteroid = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		asteroid.transform.Rotate (0, 0, rotationSpeed);
	}
}
