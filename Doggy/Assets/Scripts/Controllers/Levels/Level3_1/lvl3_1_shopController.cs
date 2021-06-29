using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_shopController : MonoBehaviour
{
    public GameObject mapa;
    private bool canBuyTime = true;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            bool hasBoughtMemory = mapa.GetComponent<lvl3_1_danceController>().getMemory();
            if (!hasBoughtMemory && GameManager.instancia.redJewels > 1 && GameManager.instancia.blueJewels > 5)
            {
                GameManager.instancia.redJewels -= 2;
                GameManager.instancia.blueJewels -= 6;
                mapa.GetComponent<lvl3_1_danceController>().setMemory(true);
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

    private void timeJoker()
    {
        timeController.ability5sec();
        canBuyTime = false;
        StartCoroutine(cronTimeOff(5));
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
