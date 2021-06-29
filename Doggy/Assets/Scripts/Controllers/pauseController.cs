using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class pauseController : GameRouting
{
    public static bool isPaused = false;
    public static bool isTienda = false;

    public GameObject pause;
    public GameObject tienda;
    public GameObject hud;

    void Start()
    {
        pause.SetActive(false);
        tienda.SetActive(false);
        hud.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            pauseGame();
        }
        if (Input.GetButtonDown("Tienda") && (GameManager.instancia.redJewels > 0 || GameManager.instancia.blueJewels > 0))
        {
            isTienda = !isTienda;
            tiendaGame();
        }
    }

    private void pauseGame()
    {
        if (isPaused)
        {
            
            pause.SetActive(true);
            Time.timeScale = 0F;
            disableHUD();
            GetComponent<Image>().enabled = true;
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1F;
            enableHUD();
            GetComponent<Image>().enabled = false;

        }
    }

    private void tiendaGame()
    {
        if (isTienda)
        {

            tienda.SetActive(true);
            Time.timeScale = 0F;
            disableHUD();
            GetComponent<Image>().enabled = true;
        }
        else
        {
            tienda.SetActive(false);
            Time.timeScale = 1F;
            enableHUD();
            GetComponent<Image>().enabled = false;

        }
    }

    private void disableHUD()
    {
        hud.SetActive(false);
    }

    private void enableHUD()
    {
        hud.SetActive(true);
    }
    public void continueLevel()
    {
        pause.SetActive(false);
        Time.timeScale = 1F;
        enableHUD();
        GetComponent<Image>().enabled = false;
    }

    public void restartLevel()
    {
        ChooseLevel(GameManager.instancia.level.ToString());
    }

    public void saveLevel()
    {
        SaveSystem.SaveGameData(GameManager.instancia.saveSlot);

    }

    public void exitLevel()
    {
        MainMenu();
    }

}
