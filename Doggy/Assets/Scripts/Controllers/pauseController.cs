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
        pause.SetActive(false);     //Escondo el menu de pausa
        tienda.SetActive(false);    //Escondo la tienda de habilidades
        hud.SetActive(true);        //Muestro el HUD
    }

    void Update()
    {
        //Verifico que se presione el boton de pausa
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            pauseGame();
        }

        //Verifico que se presione el boton tienda y que el jugador tenga gemas
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
            // Aparecer el menu de pausa
            pause.SetActive(true);
            //Para el tiempo del juego
            Time.timeScale = 0F;
            disableHUD();
            //Pone la imagen de pausa
            GetComponent<Image>().enabled = true;
        }
        else
        {
            // Desaparezco el menu de pausa
            pause.SetActive(false);
            //Continuo el tiempo
            Time.timeScale = 1F;
            enableHUD();
            //Quito la imagen de pausa
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

    //Controles del menu de pausa
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
