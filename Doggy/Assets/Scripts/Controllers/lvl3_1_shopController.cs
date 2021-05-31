using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_shopController : MonoBehaviour
{
    public GameObject mapa;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            bool hasBoughtMemory = mapa.GetComponent<lvl3_1_danceController>().getMemory();
            if (!hasBoughtMemory)
            {
                GameManager.instancia.galletas--;
                mapa.GetComponent<lvl3_1_danceController>().setMemory(true);
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
}
