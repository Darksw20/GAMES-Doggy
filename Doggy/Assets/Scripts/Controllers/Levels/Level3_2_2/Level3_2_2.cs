using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_2_2 : GameRouting
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
    public GameObject Correcto;
    public GameObject _2Correcto;

    private SpriteRenderer sTop;
    private SpriteRenderer _2sTop;
    private SpriteRenderer sBottom;

    void Start()
    {
        Correcto.SetActive(false);
        _2Correcto.SetActive(false);
        sTop = Top.GetComponent<SpriteRenderer>();
        _2sTop = _2Top.GetComponent<SpriteRenderer>();
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
                    setSabor(hit.collider.gameObject);
                else if (hit.collider.gameObject.tag == "Cono")
                    setCono(hit.collider.gameObject);
                else if (hit.collider.gameObject.tag == "Boton")
                    checkOrder();
            }
        }
    }
    private void checkOrder()
    {
        sTop.sprite = null;
        _2sTop.sprite = null;
        sBottom.sprite = null;
        if (saborActual != null)
            GameObject.Find(saborActual).GetComponent<Items>().unselectItem();
        if (conoActual != null)
            GameObject.Find(conoActual).GetComponent<Items>().unselectItem();
        if (!level1Completed)
        {
            if (saborActual == "Vainilla" && conoActual == "Cono")
            {
                Correcto.SetActive(true);
                level1Completed = true;
                Top.transform.position = new Vector3(50F, 6.7F, 0F);
            }
            saborActual = null;
            conoActual = null;
        }
        else if (!level2Completed)
        {
            if (saborActual == "Chocolate" && conoActual == "Canasta")
            {
                _2Correcto.SetActive(true);
                level2Completed = true;
            }
            saborActual = null;
            conoActual = null;
        }
        if (level1Completed && level2Completed)
        {
            GameManager.instancia.level = 9;
            GameManager.instancia.nextLevel = 10;
            //Guardo el nivel
            SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
            nextLevel();
        }
    }

    private void updateOrder()
    {
        if (saborActual == "Vainilla")
        {
            sTop.sprite = Vainilla;
            if (level1Completed)
                _2sTop.sprite = Vainilla;

        }
        else if (saborActual == "Chocolate")
        {
            sTop.sprite = Chocolate;
            if (level1Completed)
                _2sTop.sprite = Chocolate;
        }
        else if (saborActual == "Fresa")
        {
            sTop.sprite = Fresa;
            if (level1Completed)
                _2sTop.sprite = Fresa;
        }
        else
        {
            sTop.sprite = null;
            if (level1Completed)
                _2sTop.sprite = null;
        }

        if (conoActual == "Canasta")
            sBottom.sprite = Canasta;
        else if (conoActual == "Cono")
            sBottom.sprite = Cono;
        else if (conoActual == "Vaso")
            sBottom.sprite = Vaso;
        else
            sBottom.sprite = null;
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
