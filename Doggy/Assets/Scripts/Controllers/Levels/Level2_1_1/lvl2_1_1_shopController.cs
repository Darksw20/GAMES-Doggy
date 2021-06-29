using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class lvl2_1_1_shopController : MonoBehaviour
{
    public static bool hasBoughtStrenght = false;
    private bool canBuyTime = true;
    public GameObject[] piezas;
    private static readonly Random random = new Random();

    void Start()
    {
        for (int i=0; i<5;i++)
        {
            float x = (float)RandomNumberBetween(-4.0f, 24.77f);
            Debug.Log("x: " + x);
            piezas[i].transform.position = new Vector3(x, -4.0f, 31.72139f);
        }
    }


    void Update()
    {
        if (GameManager.instancia.dificulty != 2)
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
    }

    private static double RandomNumberBetween(double minValue, double maxValue)
    {
        var next = random.NextDouble();

        return minValue + (next * (maxValue - minValue));
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
