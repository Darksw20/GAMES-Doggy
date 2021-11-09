using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_2_1_shopController : MonoBehaviour
{
    private bool canBoughtCircles = true;
    private bool canBuyTime = true;
    private lvl3_2_1_controller levelController;

    private void Start()
    {
        levelController = GameObject.Find("Mapa").GetComponent<lvl3_2_1_controller>();
    }

    void Update()
    {
        if (GameManager.instancia.dificulty != 2)
        {
            if (Input.GetButton("1"))
            {
                if (GameManager.instancia.blueJewels > 2 && canBoughtCircles)
                {
                    GameManager.instancia.blueJewels -= 3;
                    circulesClues();
                    levelController.setShouldSeeCircles(true);
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
    private void timeJoker()
    {
        timeController.ability5sec();
        canBuyTime = false;
        StartCoroutine(cronTimeOff(5));
    }

    private void circulesClues()
    {
        Debug.Log("s");
        canBoughtCircles = false;
        StartCoroutine(cronTimeOffCircles(5));
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

    IEnumerator cronTimeOffCircles(int time)
    {
        GameManager.instancia.hSlot1 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot1--;
        }
        canBoughtCircles = true;
        levelController.setShouldSeeCircles(false);
    }
}
