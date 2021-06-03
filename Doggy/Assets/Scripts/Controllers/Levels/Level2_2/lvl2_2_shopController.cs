using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_2_shopController : MonoBehaviour
{
    void Update()
    {
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
