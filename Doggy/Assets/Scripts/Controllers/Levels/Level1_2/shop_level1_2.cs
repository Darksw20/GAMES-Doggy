using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_level1_2 : MonoBehaviour
{
    private bool canBuySpeed = true;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if ((GameManager.instancia.redJewels > 0 || GameManager.instancia.blueJewels > 0) && canBuySpeed)
            {
                if (GameManager.instancia.redJewels > 0)
                    GameManager.instancia.redJewels--;
                else
                    GameManager.instancia.blueJewels--;

                speedAbility();
            }
        }

        if (Input.GetButton("2"))
        {
            if ((GameManager.instancia.redJewels > 0 || GameManager.instancia.blueJewels > 0))
            {
                if (GameManager.instancia.redJewels > 0)
                    GameManager.instancia.redJewels--;
                else
                    GameManager.instancia.blueJewels--;

                timeWildcard();
            }
        }
    }

    private void speedAbility()
    {
        canBuySpeed = false;
        GameObject.Find("Ana").GetComponent<TopDownPlayerMovement>().setMoveSpeed(4f);
    }

    private void timeWildcard()
    {
        GameManager.instancia.time += 5;
    }

}
