using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeRemaining = 60f;
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

