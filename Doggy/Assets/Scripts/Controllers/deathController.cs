using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathController : GameRouting
{
    void Start()
    {
        StartCoroutine(changeLevel());
    }

    IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(3);
        GameManager.instancia.points = 0;
        GameManager.instancia.galletas = 0;
        GameManager.instancia.health = 3;
        GameManager.instancia.money = 0;
        GameManager.instancia.redJewels = 0;
        GameManager.instancia.blueJewels = 0;
        ChooseLevel(GameManager.instancia.level.ToString());
    }
}
