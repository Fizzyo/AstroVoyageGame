using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fizzyo;
using TMPro;


public class DisplayScore : MonoBehaviour
{

    public static int timesPlayerDead = 0;

    private string PointsAch = "Got more than 500 points";
    private string fullSet = "Full set without losing 50 points";
    private string dontHitAstroCycle = "Didn't hit asteroid in whole game";
    private string dontHitAstroSession = "Didn't hit asteroid in whole session";

    public static int score = 0;
    private int penalisation = 1000;
    private int scoreMultiplier = 1;
    public static bool killPlayer = false;

    public TextMeshProUGUI textbox;
    //Text textbox;
    // Use this for initialization

	void awake(){
		killPlayer = false;
		score = 0;
	}
    void Start()
    {
		killPlayer = false;
		score = 0; //textbox = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
		int highscore = PlayerPrefs.GetInt ("highscore", 0);
		if ((score / 10) > highscore) {
			PlayerPrefs.SetInt ("highscore", (score / 10));
		}
        /*if (score > 500)
        {
            FizzyoFramework.Instance.Achievements.UnlockAchievement(PointsAch);
        }*/

        if (score < 0)
        {
            textbox.text = "";
            killPlayer = true;

            timesPlayerDead++;

            PlayerPrefs.SetFloat("breathsWhenDead",MainMenu.breathsNo);
            PlayerPrefs.SetFloat("sessionsWhenDead",MainMenu.sessionsNo);
        }

        if (Player.isAlive && !pauseGame.GameIsPaused)
        {
            //Time.timeScale = 0.1f;
            score += 1 * scoreMultiplier;
        }

        textbox.text = "Score: " + (score / 10);   //<-------

        if (Player.hitAstro && breathingTest.goodBreath)
        {
            textbox.text = textbox.text + "\n -10";
            //scoreMultiplier = 4;
            score -= penalisation / scoreMultiplier;
            //textbox.color = new Color(229, 0, 0);
            textbox.color = Color.cyan;
            //Time.timeScale = 0f;
        }

        else if (Player.hitAstro)
        {
            textbox.text = textbox.text + "\n -" + penalisation;
            //scoreMultiplier = 4;
            score -= penalisation;
            //textbox.color = new Color(229, 0, 0);
            textbox.color = Color.blue;
            //Time.timeScale = 0f;
        }

        if (breathingTest.goodBreath)
        {
            textbox.text = textbox.text + "\n x4";
            scoreMultiplier = 4;
            //textbox.color = new Color(50, 0, 50);
            textbox.color = Color.red;
        }

        else
        {
            //Time.timeScale = 1;
            scoreMultiplier = 1;
            textbox.color = Color.white;
            //textbox.color = new Color(255, 255, 255, 255);
        }
		Player.hitAstro = false;
    }

}
