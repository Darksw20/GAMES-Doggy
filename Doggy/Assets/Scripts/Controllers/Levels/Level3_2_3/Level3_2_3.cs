using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_2_3 : MonoBehaviour
{

    public Sprite Chocolate;
    public Sprite Vainilla;
    public Sprite Fresa;
    public Sprite Canasta;
    public Sprite Cono;
    public Sprite Vaso;

    private string saborActual = null;
    private string conoActual = null;

    private bool level1Completed = false;
    private bool level2Completed = false;

    public GameObject Top;
    public GameObject _2Top;
    public GameObject Bottom;

    private SpriteRenderer sTop;
    private SpriteRenderer s_2Top;
    private SpriteRenderer sBottom;

    void Start()
    {
        sTop = Top.GetComponent<SpriteRenderer>();
        s_2Top = _2Top.GetComponent<SpriteRenderer>();
        sBottom = Bottom.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Sabor")
                {
                    setSabor(hit.collider.gameObject);
                } else if (hit.collider.gameObject.tag == "Cono")
                {
                    setCono(hit.collider.gameObject);
                }
            }
        }
    }
    private void checkOrder()
    {
        if (!level1Completed)
        {
            if (saborActual == "Vainilla" && conoActual == "Cono")
            {
                GameObject.Find("Vainilla").GetComponent<Items>().unselectItem();
                GameObject.Find("Cono").GetComponent<Items>().unselectItem();
                level1Completed = true;
                saborActual = null;
                conoActual = null;
                sTop.sprite = null;
                sBottom.sprite = null;
            }
        }
        else if (!level2Completed)
        {
            if (saborActual == "Chocolate" && conoActual == "Canasta")
            {
                GameObject.Find("Chocolate").GetComponent<Items>().unselectItem();
                GameObject.Find("Canasta").GetComponent<Items>().unselectItem();
                level2Completed = true;
                saborActual = null;
                conoActual = null;
                sTop.sprite = null;
                sBottom.sprite = null;
            }
        }
        if (level1Completed && level2Completed)
        {
            // next scene code
        }
    }

    private void updateOrder()
    {
        switch (saborActual)
        {
            case "Vainilla":
                sTop.sprite = Vainilla;
                break;

            case "Chocolate":
                sTop.sprite = Chocolate;
                break;

            case "Fresa":
                sTop.sprite = Fresa;
                break;

            case null:
                sTop.sprite = null;
                break;
        }
        switch (conoActual)
        {
            case "Canasta":
                sBottom.sprite = Canasta;
                break;

            case "Cono":
                sBottom.sprite = Cono;
                break;

            case "Vaso":
                sBottom.sprite = Vaso;
                break;

            case null:
                sBottom.sprite = null;
                break;
        }
        checkOrder();
    }

    private void setSabor(GameObject gameObject)
    {
        if (saborActual == null)
        {
            saborActual = gameObject.name;
            gameObject.GetComponent<Items>().selectItem();
        } else if (saborActual == gameObject.name)
        {
            gameObject.GetComponent<Items>().unselectItem();
            saborActual = null;
        } else if (saborActual != null)
        {
            GameObject.Find(saborActual).GetComponent<Items>().unselectItem();
            saborActual = gameObject.name;
            gameObject.GetComponent<Items>().selectItem();
        }
        updateOrder();
    }

    private void setCono(GameObject gameObject)
    {
        if (conoActual == null)
        {
            conoActual = gameObject.name;
            gameObject.GetComponent<Items>().selectItem();
        }
        else if (conoActual == gameObject.name)
        {
            gameObject.GetComponent<Items>().unselectItem();
            conoActual = null;
        }
        else if (conoActual != null)
        {
            GameObject.Find(conoActual).GetComponent<Items>().unselectItem();
            conoActual = gameObject.name;
            gameObject.GetComponent<Items>().selectItem();
        }
        updateOrder();
    }
}
