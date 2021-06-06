using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;

    private void Start()
    {
        GameManager.instancia.levelTime = (int)timeRemaining;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                GameManager.instancia.time = Mathf.FloorToInt(timeRemaining % 60);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
