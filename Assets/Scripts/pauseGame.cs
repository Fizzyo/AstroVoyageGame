using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public Button pauseButton;
    public Button resumeButton;
    public Button exitGame;

    public GameObject pauseMenuUI;


     void Start()
    {
		
		GameIsPaused = false;

        exitGame.GetComponent<Button>().onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        pauseButton.GetComponent<Button>().onClick.AddListener(PauseGame);
        resumeButton.GetComponent<Button>().onClick.AddListener(resumeGame);
    }

    void PauseGame()
    {
        if(GameIsPaused)
        {
            GameIsPaused = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }

        else
        {
			GameIsPaused = true;
            pauseMenuUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Paused");
            Time.timeScale = 0f;
            
        }
    }

    void resumeGame()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void ExitGame()
    {
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }

}
