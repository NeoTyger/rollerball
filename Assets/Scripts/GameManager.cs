using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameManager instance;
    [SerializeField] private TextMeshProUGUI _txtPoints;

    private int points = 5;
    private int collectedPoints = 0;
    private bool winner = false;
    private int level = 0;
    

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

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ScorePoints()
    {
        collectedPoints++;
        _txtPoints.text = "Points : " + collectedPoints * 100;

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
}
