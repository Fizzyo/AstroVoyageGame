using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour 
{
	public GameObject sessionSetupPopup;
    public static bool canPlayGame = false;

	public static int highscore;
    public static float breathsNo = 0;
    public static float sessionsNo = 0;

	public Button quitGameButton;
    public Button increaseBreaths;
    public Button decreaseBreaths;

    public Button increaseSession;
    public Button decreaseSession;

    public TextMeshProUGUI Breaths;
    public TextMeshProUGUI Sessions;


    private static float lastStoredBreaths;
    private static float lastStoredSessions;


    private void Start()
    {

        if(DisplayScore.timesPlayerDead>0)
        {
            breathsNo = PlayerPrefs.GetFloat("breathsWhenDead", 0);
            sessionsNo = PlayerPrefs.GetFloat("sessionsWhenDead", 0);

            Breaths.text = breathsNo.ToString();
            Sessions.text = lastStoredSessions.ToString();
        }


        breathsNo = PlayerPrefs.GetFloat("lastStoredBreaths", 0);
        sessionsNo = PlayerPrefs.GetFloat("lastStoredSessions", 0);

		highscore = PlayerPrefs.GetInt("highscore",0);

        lastStoredBreaths = PlayerPrefs.GetFloat("lastStoredBreaths", 0);
        lastStoredSessions = PlayerPrefs.GetFloat("lastStoredSessions", 0);

        Breaths.text = lastStoredBreaths.ToString();
        Sessions.text = lastStoredSessions.ToString();

        increaseBreaths.onClick.AddListener(Increasebr);
        decreaseBreaths.onClick.AddListener(Decreasebr);

        increaseSession.onClick.AddListener(IncreaseSess);
        decreaseSession.onClick.AddListener(DecreaseSess);
		//if (quitGameButton != null) {
		quitGameButton.onClick.AddListener (QuitGame);
		//}
    }


    private void Update()
    {
        //increaseBreaths.GetComponent<Button>().onClick.AddListener(Increasebr);
        //decreaseBreaths.GetComponent<Button>().onClick.AddListener(decreasebr);
        //increaseBreaths.onClick.AddListener(Increasebr);
        //decreaseBreaths.onClick.AddListener(decreasebr);
    }



    public void PlayGame()
    {
        if (canPlayGame)
        {
            FindObjectOfType<AudioManager>().Play("startbuttonpress");
            SceneManager.LoadScene("ChillehSnow", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Can't play game, did not input sessions and breaths.");
			if (sessionSetupPopup != null) {
				sessionSetupPopup.SetActive (true);
			}
        }
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("exitsound");
		//Debug.Log ("quitting");
		//UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //Breath Control
    public void Increasebr()
    {
            breathsNo += 0.5f;
            Breaths.text = breathsNo.ToString();
           //breaths.SetText(""+breathsNo);
    }

    public void Decreasebr()
    {
        if (breathsNo > 0)
        {
            breathsNo -= 0.5f;
            Breaths.text = breathsNo.ToString();
        }
    }

    public void IncreaseSess()
    {
        sessionsNo += 0.5f;
        Sessions.text = sessionsNo.ToString();
    }

    public void DecreaseSess()
    {
        if (sessionsNo > 0)
        {
            sessionsNo -= 0.5f;
            Sessions.text = sessionsNo.ToString();
        }
    }

}
