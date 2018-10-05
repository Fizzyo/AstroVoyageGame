using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAsteroids : MonoBehaviour
{

    GameObject player;
	private bool playerdead = false;
	private Vector3 playerpos;
	Rigidbody2D rb;
	PolygonCollider2D pc;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
		pc = gameObject.GetComponent<PolygonCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
		//if (playerdead) {
			if (transform.position.y > playerpos.y + 9f) {
				Destroy (this.gameObject);
			}
		//}
		else if (!Player.isAlive) {
			playerdead = true;
			Destroy (rb);
			Destroy (pc);
		} else {
			playerpos = player.transform.position;
		}

    }
}