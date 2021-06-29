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
        if (Input.GetButtonDown("Tienda"))
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
            GetComponent<Image>().enabled = true;
            disableHUD();
            Time.timeScale = 0F;
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
            //GetComponent<Image>().enabled = true;
            disableHUD();
            Time.timeScale = 0F;
        }
        else
        {
            tienda.SetActive(false);
            Time.timeScale = 1F;
            enableHUD();
            //GetComponent<Image>().enabled = false;

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
