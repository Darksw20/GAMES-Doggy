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

        if (GameManager.instancia.health == 1)
        {
            gO.SetActive(true);
            StartCoroutine(GameOver());
        }
        else
        {
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

    IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(3);
        ChooseLevel(GameManager.instancia.level.ToString());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        MainMenu();
    }
}
