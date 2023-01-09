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
        StartLevel();
    }

    private void StartLevel()
    {
        winner = false;
        NextLevel();

        if (!PlayerPrefs.HasKey("level"))
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.Save();
        }
        else
        {
            level = PlayerPrefs.GetInt("level");
        }
    }

    private void NextLevel()
    {
        if (level == 1 && winner == true)
        {
            winner = false;
            PlayerPrefs.SetInt("level", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level 2");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level 1");
        }
        
        StartLevel();
    }
    

    public void ScorePoints()
    {

        if (level == 1)
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

                if (!PlayerPrefs.HasKey("level"))
                {
                    level = 2;
                    PlayerPrefs.SetInt("level", level);
                    PlayerPrefs.Save();
                }
                
                NextLevel();
            }
        }
        else if (level == 2)
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
            }
        }
    }
}
