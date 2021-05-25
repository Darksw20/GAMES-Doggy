using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_2_shopController : MonoBehaviour
{
    private TopDownPlayerMovement top;

    private bool hasBoughtRun = false;
    private bool hasBoughtTime = false;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtRun)
            {
                GameManager.instancia.galletas--;
                top.setMoveSpeed(4f);
            }
        }

        if (Input.GetButton("2"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtTime)
            {
                GameManager.instancia.galletas--;
                GameManager.instancia.time += 5;
            }
        }
    }
}
