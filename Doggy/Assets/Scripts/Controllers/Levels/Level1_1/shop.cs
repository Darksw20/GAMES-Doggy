using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class shop : MonoBehaviour
{
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;

    private bool canBuyLight = true;
    private bool canBuySniff = true;

    void Update()
    {
        Debug.Log(GameManager.instancia.galletas);
        if(Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && canBuySniff)
            {
                GameManager.instancia.galletas--;
                // code
            }
        }

        if(Input.GetButton("2"))
        {
            if(GameManager.instancia.galletas > 0 && canBuyLight)
            {
                GameManager.instancia.galletas--;
                turnOnLights();
            }
        }
    }
    private void turnOnLights()
    {
        canBuyLight = false;
        if (light1 != null)
            light1.enabled = true;
        if (light2 != null)
            light2.enabled = true;
        if (light3 != null)
            light3.enabled = true;
        StartCoroutine(lightAbility());
    }

    IEnumerator lightAbility()
    {
        yield return new WaitForSeconds(10);
        if (light1 != null)
            light1.enabled = false;
        if (light2 != null)
            light2.enabled = false;
        if (light3 != null)
            light3.enabled = false;
        canBuyLight = true;
    }

}
