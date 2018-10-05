using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fizzyo;

public class Player : MonoBehaviour {

	public float movementSpeed;

    public GameObject playerLostUI;

	private bool movingLeft;

	public GameObject explosionGraphic;

	public float sideMax = 2f;
	public float sideSpeed = 1f;
	public int turnRadius = 7;
	public int comboBounceWall = 0;
	public static int asteroidHits = 0;

	public static bool hitAstro = false;

	public static bool isAlive = true;

	private void Start()
	{
		Time.timeScale = 1f;
		asteroidHits = 0;
		hitAstro = false;
		movingLeft = true;
        FindObjectOfType<AudioManager>().Play("bgMusic");
		isAlive = true;

	}

	private void Update()
	{

        //KILL PLAYER
		if(DisplayScore.killPlayer)
		{
			isAlive = false;
            FindObjectOfType<AudioManager>().Pause("bgMusic");
            FindObjectOfType<AudioManager>().Pause("goodBreath");
            FindObjectOfType<AudioManager>().Play("playerlost");
			//Instantiate (playerLostUI);
            //playerLostUI.SetActive(true);
			Die();
		}

		//hitAstro = false;
		//float pressure = FizzyoFramework.Instance.Device.Pressure();
		//print(pressure);


		transform.TransformVector(Vector3.down * Time.deltaTime * movementSpeed);

		//Player movement
		if(FizzyoFramework.Instance.Device.ButtonDown())
		{
			movingLeft = !movingLeft;
		}

		if (movingLeft) { // smooth direction change
			if (sideSpeed > -sideMax) {
				sideSpeed -=  sideMax / turnRadius;
			}
		} else {
			if (sideSpeed < sideMax) {
				sideSpeed += sideMax / turnRadius;
			}
		}

		//bounc\\e player off the wall
		GameObject player = this.gameObject;

		if (player.transform.position.x < -5.7 || player.transform.position.x > 6.8) {
			sideSpeed = -sideSpeed;
			movingLeft = !movingLeft;
			comboBounceWall++;

			if(comboBounceWall == 4)
			{
				print("Combo breaker activated.");
				print(comboBounceWall);
				comboBounceWall = 0;
			}
		}

		transform.Translate(sideSpeed * Time.deltaTime, -movementSpeed * Time.deltaTime, 0);

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacle")
		{
			Time.timeScale = 0.6f;
			//Die ();
			//Give player three lives
			/*
            if(asteroidHits == 3)
            {
                isAlive = false;
                Die();
            }
            asteroidHits++;
            */
			if (explosionGraphic != null) {
				Instantiate (explosionGraphic,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-0.09f),Quaternion.identity);
			}
			hitAstro = true;
            FindObjectOfType<AudioManager>().Play("astroHit");
			//FizzyoFramework.Instance.Achievements.PostScore(score);
			//Application.Quit();

		}
	}
	private void OnTriggerExit2D(Collider2D other){
		Time.timeScale = 1f;
	}


	public void Die()
	{
		print("Player Dead.");
		//FizzyoFramework.Instance.Achievements.PostScore(score);
        //FizzyoFramework.Destroy();
		//Application.Quit();
		Destroy(this.gameObject);
	}

}