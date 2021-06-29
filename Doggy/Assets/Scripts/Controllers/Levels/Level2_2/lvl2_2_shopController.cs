using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lvl2_2_shopController : MonoBehaviour
{
    private bool canBuyTime = true;

    void Update()
    {
        if (Input.GetButton("1"))
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
        GameManager.instancia.hSlot1 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot1--;
        }
        canBuyTime = true;
    }
}
