using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
		player = GameObject.FindWithTag ("Player");
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
		if (Player.isAlive)
		{
			if (player == null) {
				player = GameObject.FindWithTag ("Player");
				offset = transform.position - player.transform.position;
			}

            transform.position = player.transform.position + offset;
        }
    }
}
