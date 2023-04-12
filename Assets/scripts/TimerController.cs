using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public static float remainingTime;
    private bool isPaused;
    private bool isStarted;


    void Start()
    {
        ResetTimer();
        Invoke("StartTimer", 1f);
    }

    void Update()
    {
        if (!isPaused && isStarted)
        {
            remainingTime = startTime - Time.time;
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                isStarted = false;
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        if (!isStarted)
        {
            isStarted = true;
            startTime = Time.time + remainingTime;
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    public void ResetTimer()
    {
        isStarted = false;
        isPaused = false;
        remainingTime = 5 * 60;        
        Time.timeScale = 1;
        UpdateTimerText();
    }
}
