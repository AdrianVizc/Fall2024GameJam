using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    public bool difficultySelected;
    public bool endGame;
    private float elapsedTime;

    private int minutes;
    private int seconds;
    private double milliseconds;

    void Start()
    {
        difficultySelected = false;
        endGame = false;
        elapsedTime = 0.0f;
    }

    void FixedUpdate()
    {
        if (difficultySelected && !endGame)
        {
            elapsedTime += Time.deltaTime;

            minutes = Mathf.FloorToInt(elapsedTime / 60);
            seconds = Mathf.FloorToInt(elapsedTime % 60);
            milliseconds = (elapsedTime - Math.Truncate(elapsedTime)) * 100;
            if (milliseconds > 99)
            {
                milliseconds = 0;
            }

            timerText.text = string.Format("{0:00}:{1:00}:", minutes, seconds) + string.Format("{0:00}", milliseconds);
        }

    }
}
