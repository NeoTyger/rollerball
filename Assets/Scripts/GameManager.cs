using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    private Timer _timer;
    private PlayerLife _playerLife;
    public TextMeshProUGUI _txtPoints;
    public TextMeshProUGUI _txtLives;
    public TextMeshProUGUI _txtLevel;
    public TextMeshProUGUI _txtGameOver;
    public TextMeshProUGUI _txtWinner;
    public Button _btnRestartGame;
    public Button _btnExit;
    public GameObject pausePanel;

    private int points = 5;
    public int collectedPoints;
    private bool winner = false;
    public int playerLives = 3;

    private int currentLevel = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        StartLevel();
        _timer = FindObjectOfType<Timer>();
        _playerLife = FindObjectOfType<PlayerLife>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf == true)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            pausePanel.SetActive(pausePanel.activeSelf?false:true);
        }
    }

    public void StartLevel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        collectedPoints = 0;
        _txtPoints.text = "Points : " + collectedPoints;
        _txtLives.text = "Lives : " + playerLives;
        _txtLevel.text = "Level " + currentLevel;
        _txtGameOver.gameObject.SetActive(false);
        _txtWinner.gameObject.SetActive(false);
        _btnRestartGame.gameObject.SetActive(false);
        _btnExit.gameObject.SetActive(false);
        _btnExit.onClick.AddListener(ExitGame);
        _btnRestartGame.onClick.AddListener(RestartGame);
    }

    public void SubtractLives()
    {
        playerLives--;
        _txtLives.text = "Lives : " + playerLives;
        
        ResetText();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void ScorePoints()
    {
        collectedPoints++;
        _txtPoints.text = "Points : " + collectedPoints * 100;

        if (collectedPoints == points && SceneManager.GetActiveScene().buildIndex <2)
        {
            LoadNextLevel();
            collectedPoints = 0;
            playerLives = 3;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && collectedPoints == points)
        {
            winner = true;
            _txtWinner.gameObject.SetActive(true);
            _btnRestartGame.gameObject.SetActive(true);
            _btnExit.gameObject.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Time.timeScale = 0;
        }
    }

    private void LoadNextLevel()
    {
        currentLevel++;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        ResetText();
        StartLevel();
    }

    public void ResetText()
    {
        collectedPoints = 0;
        _txtPoints.text = "Points : " + collectedPoints;
        _txtLevel.text = SceneManager.GetActiveScene().name;
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        
        // hacer que el cursor vuelva a ser invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        ResetGame();

        // hacer que el cursor vuelva a ser invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void ResetGame()
    {
        Timer.timerIsOn = true;
        _timer.currentTime = 300;
        collectedPoints = 0;
        playerLives = 3;
        currentLevel = 1;
        _txtPoints.text = "Points : " + collectedPoints;
        _txtLives.text = "Lives : " + playerLives;
        _txtLevel.text = "Level " + currentLevel;
        winner = false;
        _txtGameOver.gameObject.SetActive(false);
        _txtWinner.gameObject.SetActive(false);
        _btnRestartGame.gameObject.SetActive(false);
        _btnExit.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _txtGameOver.gameObject.SetActive(true);
        _btnRestartGame.gameObject.SetActive(true);
        _btnExit.gameObject.SetActive(true);
            
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // detener el tiempo
        Time.timeScale = 0;
    }

}
