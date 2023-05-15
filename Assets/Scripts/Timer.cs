using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;

    public static bool timerIsOn = true;

    public float currentTime = 0;

    [Space]
    [SerializeField] TextMeshProUGUI timeText;

    private GameManager _gameManager;

    private void Start()
    {
        currentTime = startTime;
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (timerIsOn)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = 0;
                timerIsOn = false;

                GameOver();
            }

            DysplayTime();
        }
    }

    void DysplayTime()
    {
        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = currentTime % 60;

        timeText.text = minutes + ":" + Mathf.RoundToInt(seconds);
    }


    public void GameOver()
    {
        _gameManager.GameOver();
    }
}
