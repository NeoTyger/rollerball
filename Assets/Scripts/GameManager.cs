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

    private int points = 0;
    private bool winner = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        winner = false;
    }
    

    public void ScorePoints()
    {
        if (points < 5)
        {
            points++;
            _txtPoints.text = "Points : " + points * 100;
        }
        else
        {
            points++;
            _txtPoints.text = "Points : " + points * 100;
            winner = true;
            NextLevel();
        }
    }
}
