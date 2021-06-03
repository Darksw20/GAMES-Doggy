using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_2_1_shopController : MonoBehaviour
{
    private bool hasBoughtCircles = false;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtCircles)
            {
                GameManager.instancia.galletas--;
                GameObject.Find("Mapa").GetComponent<lvl3_2_1_controller>().setShouldSeeCircles(true);
                hasBoughtCircles = true;
            }
        }
    }
}
