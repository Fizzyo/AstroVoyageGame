using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fizzyo;
using UnityEngine.UI;
using TMPro;

public class breathingTest : MonoBehaviour {

	int score = 0;
    float breaths = MainMenu.breathsNo;
    float sessions = MainMenu.sessionsNo;

	public static int breathCount = 0;
	public static bool goodBreath = false;
	public static int goodBreathCount = 0;
	public int endBoostTime = 4;
	private float lastGoodBreathTime = 0;
    public TextMeshProUGUI breathsToFinish;
    public TextMeshProUGUI sessionsToFinish;

	Text pressureShow;

	    //private string PerfectBreathUID = "";

	void Start()
	{
		goodBreath = false;
		goodBreathCount = 0;
		breathCount = 0;
        pressureShow = GetComponent<Text>();
	    FizzyoFramework.Instance.Recogniser.BreathStarted += OnBreathStarted;
	    FizzyoFramework.Instance.Recogniser.BreathComplete += OnBreathEnded;
        sessionsToFinish.text = "Sessions to finish:\n" + sessions.ToString();
        breathsToFinish.text = "Breaths to finish:\n" + breaths.ToString();
	}

	void Update()
	{

		if (goodBreath) {
			if (Time.time >= endBoostTime + lastGoodBreathTime) {
				goodBreath = false;
		}
			
	    //get exhale pressure between -1 and 1
	    float pressure = FizzyoFramework.Instance.Device.Pressure();
	    if (FizzyoFramework.Instance.Device.ButtonDown())
	    {
	        Debug.Log("button pressed");
	    }
        if(Player.isAlive)
	        {
            if (Player.hitAstro)
            {
                pressureShow.text = "-100";
                //print(pressure);
            }

            if (Player.hitAstro && goodBreath)
            {
                pressureShow.text = "-25";
                //print(pressure);

            }

            else
            {
                pressureShow.text = "";
            }
	        }
	    //Debug.Log("Exhale pressure: " + pressure);
	}
	}

	void OnBreathStarted(object sender)
	{
	    Debug.Log("Breath started");
		goodBreath = false;
	}


	void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
	{
	    
	    breathCount++;

		if(breaths > 1)
        {
			breaths--;
			breathsToFinish.text = ("Breaths to finish:\n"+(breaths).ToString());
        }

        else
        {
			breaths = MainMenu.breathsNo;
			sessions = sessions - 1;
			breathsToFinish.text = ("Breaths to finish:\n"+(breaths).ToString());
			sessionsToFinish.text = "Sessions to finish:\n" + sessions.ToString();
                
        }


	    print(e.BreathQuality);
	    print(breathCount);

	        //e.BreathQuality;
	    if (e.BreathQuality >= 2)
	    {
	    		//breathCount++;
	            //pressureShow.color = new Color32(255, 255, 255, 255);
	            //DisplayScore.score++;
	            //pressureShow.color = new Color32(0, 0, 0, 0);
			Debug.Log("mediocre breath");
	        
	    }
	    if (e.BreathQuality >= 4)
	    {
	            //FizzyoFramework.Instance.Achievements.UnlockAchievement(PerfectBreathUID);
			goodBreath = true;
			lastGoodBreathTime = Time.time;
			PopupManager.triggered = false;
			//PopupManager.triggered = false;

            FindObjectOfType<AudioManager>().Play("goodBreath");

			if (Player.isAlive && goodBreathCount < 5) {
				goodBreathCount += 1;
			}
	            Debug.Log("Excellent Breath - Double Points");
	            pressureShow.color = new Color32(254, 152, 203, 255);
	            //DisplayScore.score *= 2;
	            //pressureShow.color = new Color32(255, 255, 255, 255);
	    }
	       

		if (breaths <= 0 && sessions <= 0)
	    {
	        FizzyoFramework.Instance.Achievements.PostScore(score);
	        
            sessionsToFinish.text = "Session Ended";
			breathsToFinish.text = "No more breaths left.";
	        //Application.Quit();
	    }

	}
}
