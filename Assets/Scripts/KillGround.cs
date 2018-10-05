using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGround : MonoBehaviour
{

    GameObject player;
	private Vector3 playerpos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		if (Player.isAlive) {
			playerpos = player.transform.position;
		}
        if (transform.position.y > playerpos.y + 30f)
        {
            Destroy(this.gameObject);
        }
    }
}