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
    public TextMeshProUGUI _txtPoints;
    public TextMeshProUGUI _txtGameOver;
    public Button _btnRestartGame;
    public Button _btnExit;
    
    private int points = 5;
    public int collectedPoints;
    private bool winner = false;
    private int level = 0;
    public int playerLives = 3;
    


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
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        collectedPoints = 0;
        _txtPoints.text = "Points : " + collectedPoints;
        _txtGameOver.text = "Game Over";
        _txtGameOver.gameObject.SetActive(false);
        _btnRestartGame.gameObject.SetActive(false);
        _btnExit.gameObject.SetActive(false);
        _btnExit.onClick.AddListener(ExitGame);
        _btnRestartGame.onClick.AddListener(RestartGame);
    }

    public void SubtractLives()
    {
        playerLives--;
        
        ResetText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        if (playerLives <= 0)
        {
            Time.timeScale = 0;
            _txtGameOver.gameObject.SetActive(true);
            _btnRestartGame.gameObject.SetActive(true);
            _btnExit.gameObject.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // detener el tiempo
            Time.timeScale = 0;
        }
    }

    public void ScorePoints()
    {
        collectedPoints++;
        _txtPoints.text = "Points : " + collectedPoints;

        if (collectedPoints == points)
        {
            LoadNextLevel();
            collectedPoints = 0;
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ResetText()
    {
        collectedPoints = 0;
        _txtPoints.text = "Points : " + collectedPoints;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        // hacer que el cursor vuelva a ser invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void ResetGame()
    {
        collectedPoints = 0;
        playerLives = 3;
        level = 0;
        winner = false;
        _txtGameOver.gameObject.SetActive(false);
        _btnRestartGame.gameObject.SetActive(false);
        _btnExit.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
