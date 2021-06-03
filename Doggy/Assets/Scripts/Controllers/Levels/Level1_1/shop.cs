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
        if(Input.GetButton("1"))
        {
            if ((GameManager.instancia.redJewels > 0 || GameManager.instancia.blueJewels > 0) && canBuySniff)
            {
                if (GameManager.instancia.redJewels > 0)
                    GameManager.instancia.redJewels--;
                else
                    GameManager.instancia.blueJewels--;

                sniffAbility();
            }
        }

        if(Input.GetButton("2"))
        {
            if ((GameManager.instancia.redJewels > 0 || GameManager.instancia.blueJewels > 0) && canBuyLight)
            {
                if (GameManager.instancia.redJewels > 0)
                    GameManager.instancia.redJewels--;
                else
                    GameManager.instancia.blueJewels--;

                lightWildcard();
            }
        }
    }

    private void sniffAbility()
    {

    }

    private void lightWildcard()
    {
        canBuyLight = false;
        if (light1 != null)
            light1.enabled = true;
        if (light2 != null)
            light2.enabled = true;
        if (light3 != null)
            light3.enabled = true;
        StartCoroutine(lightWildcardOff());
    }

    IEnumerator lightWildcardOff()
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
