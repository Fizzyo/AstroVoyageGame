using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawning : MonoBehaviour {

    public GameObject player;
	private bool endScreenFlood = false;

    private GameObject obstacle;
    public float amountOfObstacles;
	public List<GameObject> obstacles = new List<GameObject>();
	private int randInt;
	private Vector3 playerPos;
	private float delayTime;

	
	public float minX, maxX;

    public void Start()
    {
		int difficulty_bonus;
		difficulty_bonus = (DisplayScore.score/1000);
        player = GameObject.FindWithTag("Player");
		delayTime = Time.fixedTime + 1f;

		for (int i = 0; i < (amountOfObstacles + difficulty_bonus*3); i++)
        {
            float xAxis,yAxis;

			randInt = Random.Range (0, obstacles.Count);
			obstacle = obstacles [randInt];
            xAxis = Random.Range(minX, maxX);
            yAxis = Random.Range(player.transform.localPosition.y - 10, transform.localPosition.y - 30);

            Vector3 pos = new Vector3(xAxis,yAxis,-0.1f);
            Instantiate(obstacle.transform,pos,Quaternion.identity);

        }
    }
	void FixedUpdate(){
		player = GameObject.FindWithTag("Player");
		if (Time.fixedTime >= delayTime) {
			delayTime = Time.fixedTime + 1f;
			if (Player.isAlive) {
				playerPos = player.transform.position;
			}

			
			if (Player.isAlive == false || endScreenFlood) {
				endScreenFlood = true;
				for (int i = 0; i < 9 ;i++) {
					float xAxis, yAxis,zAxis;

					randInt = Random.Range (0, obstacles.Count);
					obstacle = obstacles [randInt];
					xAxis = Random.Range (minX, maxX);
					yAxis = Random.Range (playerPos.y - 15, playerPos.y - 14);
					zAxis = Random.Range (-1f, 0f);

					Vector3 pos = new Vector3 (xAxis, yAxis, zAxis);
					Instantiate (obstacle.transform, pos, Quaternion.identity);

				}
			}
		}
	}				


}
