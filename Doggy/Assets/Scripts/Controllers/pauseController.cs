using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseController : MonoBehaviour
{
    public static bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseGame();
        }
    }

    private void pauseGame()
    {
        if (isPaused)
        {
            GetComponent<Image>().enabled = true;
            disableHUD();
            Time.timeScale = 0F;
        }
        else
        {
            Time.timeScale = 1F;
            enableHUD();
            GetComponent<Image>().enabled = false;

        }
    }

    private void disableHUD()
    {
        foreach (Transform child in GameObject.Find("Hud").transform)
        {
            if (child.name != "Pause menu")
            {
                child.localScale = new Vector3(0, 0, 0);
            } else if (child.name == "Shop")
            {
                foreach(Transform subchild in child)
                {
                    subchild.localScale = new Vector3(0, 0, 0);
                }
            }
        }
    }

    private void enableHUD()
    {
        foreach (Transform child in GameObject.Find("Hud").transform)
        {
            if (child.name != "Pause menu")
            {
                child.localScale = new Vector3(1, 1, 0);
            }
            else if (child.name == "Shop")
            {
                foreach (Transform subchild in child)
                {
                    subchild.localScale = new Vector3(1, 1, 0);
                }
            }
        }
    }

}
