using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public GameObject backgroundImage;

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
                disableHUD();
                backgroundImage.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    private void disableHUD()
    {
        foreach (Transform child in GameObject.Find("Hud").transform)
        {
            if (child.name != "BackgroundImage")
            {
                child.localScale = new Vector3(0, 0, 0);
            }
            else if (child.name == "Shop")
            {
                foreach (Transform subchild in child)
                {
                    subchild.localScale = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
