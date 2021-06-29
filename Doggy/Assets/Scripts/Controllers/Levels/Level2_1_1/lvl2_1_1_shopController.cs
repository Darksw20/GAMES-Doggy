using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_1_1_shopController : MonoBehaviour
{

    public static bool hasBoughtStrenght = false;
    private bool canBuyTime = true;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.redJewels > 1 && GameManager.instancia.blueJewels > 2 && !hasBoughtStrenght)
            {
                GameManager.instancia.blueJewels -= 3;
                GameManager.instancia.redJewels -= 2;

                timeStrenght();
            }
        }

        if (Input.GetButton("2"))
        {
            if (GameManager.instancia.blueJewels > 2 && canBuyTime)
            {
                GameManager.instancia.blueJewels -= 3;
                GameManager.instancia.time += 5;
                timeJoker();
            }
        }
    }

    private void timeStrenght()
    {
        hasBoughtStrenght = true;
        StartCoroutine(strenghtOff(10));
    }

    private void timeJoker()
    {
        timeController.ability5sec();
        canBuyTime = false;
        StartCoroutine(cronTimeOff(5));
    }

    IEnumerator strenghtOff(int time)
    {
        GameManager.instancia.hSlot1 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot1--;
        }
        hasBoughtStrenght = false;
    }

    IEnumerator cronTimeOff(int time)
    {
        GameManager.instancia.hSlot2 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot2--;
        }
        canBuyTime = true;
    }
}
