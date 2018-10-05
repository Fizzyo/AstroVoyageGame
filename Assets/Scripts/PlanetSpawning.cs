using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawning : MonoBehaviour {

	public GameObject player;

	private GameObject obstacle;
	public float amountOfObstacles;
	public List<GameObject> obstacles = new List<GameObject>();
	private int randInt;
	private Vector3 playerPos;


	public float minX, maxX;

	public void Start()
	{
		player = GameObject.FindWithTag("Player");

		for (int i = 0; i < amountOfObstacles; i++)
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
}
