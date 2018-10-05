using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deadMenu : MonoBehaviour {

    public Button restartGame;
    public Button exitgame;

    public GameObject deathScene;
    // Update is called once per frame
    void Update()
    {
        restartGame.GetComponent<Button>().onClick.AddListener(reloadGame);
        exitgame.GetComponent<Button>().onClick.AddListener(exitGame);
    }

    void reloadGame()
    {
        breathingTest.breathCount = 0;
        float initialbreaths = MainMenu.breathsNo;
        float initialsessions = MainMenu.sessionsNo;

        MainMenu.breathsNo = PlayerPrefs.GetFloat("breathsWhenDead",initialbreaths);
        MainMenu.sessionsNo = PlayerPrefs.GetFloat("sessionsWhenDead",initialsessions);

        deathScene.SetActive(false);
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Restart",LoadSceneMode.Single);
    }

    void exitGame()
    {
        //Application.Quit();
		deathScene.SetActive(false);
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
		SceneManager.UnloadSceneAsync (0);
    }
}
