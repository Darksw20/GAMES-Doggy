using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathController : GameRouting
{
    public GameObject gO;
    public GameObject mO;
    void Start()
    {
        gO.SetActive(false);
        mO.SetActive(false);

        //Aqui se verifica si es un GameOver o
        //si nada mas se quita una vida
        if (GameManager.instancia.health <= 1)
        {
            gO.SetActive(true);
            StartCoroutine(GameOver());
        }
        else
        {
            //Muestra la ventana de mision fallida y
            //resetear los datos del jugador
            mO.SetActive(true);
            GameManager.instancia.points = 0;
            GameManager.instancia.galletas = 0;
            GameManager.instancia.health--;
            GameManager.instancia.money = 0;
            GameManager.instancia.redJewels = 0;
            GameManager.instancia.blueJewels = 0;
            StartCoroutine(changeLevel());
        }
    }

    //Espera 3 segundos y te envia al nivel en el que estés
    IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(3);
        ChooseLevel(GameManager.instancia.level.ToString());
    }

    //Espera 3 segundos y te envia al menu principal
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        MainMenu();
    }
}
