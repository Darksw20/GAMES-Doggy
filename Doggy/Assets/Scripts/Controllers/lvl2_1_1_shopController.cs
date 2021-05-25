using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_1_1_shopController : MonoBehaviour
{

    private bool hasBoughtStrenght = false;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtStrenght)
            {
                GameManager.instancia.galletas--;
                hasBoughtStrenght = true;
            }
        }

        if (Input.GetButton("2"))
        {
            if (GameManager.instancia.galletas > 0)
            {
                GameManager.instancia.galletas--;
                GameManager.instancia.time += 5;
            }
        }
    }

    public bool getStrenght()
    {
        return hasBoughtStrenght;
    }
}
