using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    const int STARTING_ENEMIES = 6;

    public static int counter;

    public static bool isPaused = false;
    public static bool gameOver = false;

    public GameObject enemyType;
    public GameObject canvas;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    private int numberOfEnemies;

    private Text waveText;
    private int wave;
    //Use this for initialization
    void Start () {

        wave = 0;
        counter = 0;
        numberOfEnemies = STARTING_ENEMIES;

        waveText = canvas.GetComponentInChildren<Text>();

        waveText.text = "Wave: " + wave;

        pauseMenu.SetActive(false);
        gameOverScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(counter == 0)
        {
            wave++;
            waveText.text = "Wave: " + wave;

            for (int i = 0; i < numberOfEnemies; i++)
            {
                Instantiate(enemyType);
                counter++;
            }

            numberOfEnemies++;
        }

        if(gameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        gameOver = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
