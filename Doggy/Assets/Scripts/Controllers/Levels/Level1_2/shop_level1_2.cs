using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_level1_2 : MonoBehaviour
{
    private bool canBuySpeed = true;
    private bool canBuyTime = true;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.redJewels > 1 && GameManager.instancia.blueJewels > 2 && canBuySpeed)
            {
                GameManager.instancia.blueJewels -= 3;
                GameManager.instancia.redJewels -= 2;

                speedAbility();
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

    private void speedAbility()
    {
        canBuySpeed = false;
        GameObject.Find("Ana").GetComponent<TopDownPlayerMovement>().setMoveSpeed(4f);
        StartCoroutine(speedAbilityOff(10));
    }

    private void timeJoker()
    {
        timeController.ability5sec();
        canBuyTime = false;
        StartCoroutine(cronTimeOff(5));
    }

    IEnumerator speedAbilityOff(int time)
    {
        GameManager.instancia.hSlot1 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot1--;
        }
        canBuySpeed = true;
        GameObject.Find("Ana").GetComponent<TopDownPlayerMovement>().setMoveSpeed(2f);
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

