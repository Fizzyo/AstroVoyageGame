using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{

    public GameObject track;


    public bool spawned;


	void Start(){

	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !spawned)
        {
			Vector3 pos = new Vector3(transform.parent.position.x, (transform.parent.position.y - transform.parent.GetComponent<Renderer>().bounds.size.y), transform.parent.position.z);
            Instantiate(track.transform, pos, transform.parent.rotation);
            //print("Generating level.");
            spawned = true;
        }
    }
    
}

