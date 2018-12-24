using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject[] canvases;
    public GameObject pauseCanvas;
    public GameObject storeCanvas;
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    public Text scoreText;
    public Text timeRemainingText;
    public Text storeCredits;

    private GameManager gameManager;

    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateUI();

        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        OpenCanvas(pauseCanvas);
    }

    public void ResumeGame()
    {
        if(!gameOver)
        {
            Time.timeScale = 1;
            OpenCanvas(gameCanvas);
        }
        else if (gameOver)
        {
            OpenCanvas(gameOverCanvas);
        }
        
    }

    public void GameOver()
    {
        OpenCanvas(gameOverCanvas);
        gameOver = true;
    }

    public void OpenStore()
    {
        OpenCanvas(storeCanvas);
    }

    public void goToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + gameManager.score;
        timeRemainingText.text = "Time Remaining: " + gameManager.timeRemaining;
        storeCredits.text = "Store Credits: " + gameManager.score;
    }

    public void OpenCanvas(GameObject canvasToOpen)
    {
        foreach(GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        canvasToOpen.SetActive(true);
    }
}
