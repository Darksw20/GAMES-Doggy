using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lvl1_1_shopController : MonoBehaviour
{
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;

    private bool hasBoughtLight = false;
    private bool hasBoughtSniff = false;

    private void turnOnLights()
    {
        hasBoughtLight = true;
        if (light1 != null)
            light1.enabled = true;
        if (light2 != null) 
            light2.enabled = true;
        if (light3 != null) 
            light3.enabled = true;
    }

    void Update()
    {
        if(Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtSniff)
            {
                GameManager.instancia.galletas--;
                // code
            }
        }

        if(Input.GetButton("2"))
        {
            if(GameManager.instancia.galletas > 0 && !hasBoughtLight)
            {
                GameManager.instancia.galletas--;
                turnOnLights();
            }
        }
    }
}
