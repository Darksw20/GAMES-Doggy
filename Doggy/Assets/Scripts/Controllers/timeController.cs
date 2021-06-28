using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeController : MonoBehaviour
{
    public float initialTime;
    public static float timeRemaining;
    public static bool timerIsRunning = false;

    private void Start()
    {
        timeRemaining = initialTime;
        GameManager.instancia.levelTime = (int)timeRemaining;
        GameManager.instancia.time = (int)timeRemaining;
        
        Debug.Log("Ins " + GameManager.instancia.time);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            Debug.Log("time re " + timeRemaining);
            if (GameManager.instancia.time > 0)
            {
                timeRemaining -= Time.deltaTime;
                GameManager.instancia.time = (int)timeRemaining;
            }
            else
            {
                SceneManager.LoadScene("Death");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public static void ability5sec()
    {
        timeRemaining += 5;
    }
}
