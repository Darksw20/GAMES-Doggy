using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class shop_lvl1_1 : MonoBehaviour
{
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;

    private bool canBuyLight = true;
    private bool canBuySniff = true;
    private bool canBuyTime = true;

    private bool renderLine = false;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    public float Tiempo = 0.0f;
    public bool DebeAumentar = false;

    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.sortingLayerName = "Background";

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

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
        if (Input.GetButton("3"))
        {
            if (GameManager.instancia.galletas > 0 && canBuyTime)
            {

                GameManager.instancia.galletas--;
                GameManager.instancia.time += 5;
                timeController.ability5sec();
                timeJoker();
            }
        }

        if (renderLine)
            renderSniff();
    }

    private void renderSniff()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (light1 != null)
        {
            lineRenderer.SetPosition(0, GameObject.Find("Max").GetComponent<Transform>().localPosition);
            lineRenderer.SetPosition(1, GameObject.Find("galleta1").GetComponent<Transform>().localPosition);
        }
        else if (light2 != null)
        {
            lineRenderer.SetPosition(0, GameObject.Find("Max").GetComponent<Transform>().localPosition);
            lineRenderer.SetPosition(1, GameObject.Find("galleta2").GetComponent<Transform>().localPosition);
        }
        else if (light3 != null)
        {
            lineRenderer.SetPosition(0, GameObject.Find("Max").GetComponent<Transform>().localPosition);
            lineRenderer.SetPosition(1, GameObject.Find("galleta3").GetComponent<Transform>().localPosition);
        }
        else
        {
            lineRenderer.enabled = false;
            renderLine = false;
        }
    }

    private void sniffAbility()
    {
        renderLine = true;
        canBuySniff = false;
        
        StartCoroutine(sniffAbilityOff(10));
    }

    private void timeJoker()
    {
        canBuyTime = false;
        StartCoroutine(cronTimeOff(5));
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
        StartCoroutine(lightWildcardOff(10));
    }

    IEnumerator sniffAbilityOff(int time)
    {
        GameManager.instancia.hSlot1 = time;
        for (int i=0;i<time ;i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot1--;
        }
        renderLine = false;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        canBuySniff = true;
    }

    IEnumerator lightWildcardOff(int time)
    {
        GameManager.instancia.hSlot2 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot2--;
        }
        if (light1 != null)
            light1.enabled = false;
        if (light2 != null)
            light2.enabled = false;
        if (light3 != null)
            light3.enabled = false;
        canBuyLight = true;
    }

    IEnumerator cronTimeOff(int time)
    {
        GameManager.instancia.hSlot3 = time;
        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1);
            GameManager.instancia.hSlot3--;
        }
        canBuyTime = true;
    }

}
