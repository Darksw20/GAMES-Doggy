using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_1_1_itemsController : MonoBehaviour
{
    public GameObject llanta1;
    public GameObject llanta2;
    public GameObject llanta3;
    public GameObject llanta4;
    public GameObject caja;

    private int piecesFound = 0;
    private int carryingItems = 0;

    void Start()
    {
        llanta1.SetActive(false);
        llanta2.SetActive(false);
        llanta3.SetActive(false);
        llanta4.SetActive(false);
        caja.SetActive(false);
    }

    private void removeItem()
    {
        llanta1.SetActive(false);
        llanta2.SetActive(false);
        llanta3.SetActive(false);
        llanta4.SetActive(false);
        caja.SetActive(false);
    }

    private void addItem(string type)
    {
        if(type == "box")
        {
            caja.SetActive(true);
        }
        else
        {
            if(!lvl2_1_1_shopController.getStrenght())
            {
                llanta1.SetActive(true);
            }
            else
            {
                if (piecesFound == 1)
                    llanta1.SetActive(true);
                if (piecesFound == 2)
                    llanta2.SetActive(true);
                if (piecesFound == 3)
                    llanta3.SetActive(true);
                if (piecesFound == 4)
                    llanta4.SetActive(true);
            }
        }
    }

    public void pickItem(GameObject gameObject)
    {
        // Si el jugador compró la habilidad de fuerza
        if(lvl2_1_1_shopController.getStrenght())
        {
            addItem(gameObject.name);
            Destroy(gameObject);
            carryingItems++;
            Debug.Log("Recogiste un item, regrésalo al pájaro o recoje más");
        }
        else
        {
            Debug.Log("Ya estás cargando un item");
            if (carryingItems == 0)
            {
                addItem(gameObject.name);
                Destroy(gameObject);
                carryingItems++;
                Debug.Log("Recogiste un item, regrésalo al pájaro");
            }
        }
    }

    public void giveItem()
    {
        if(carryingItems != 0)
        {
            removeItem();
            piecesFound += carryingItems;
            carryingItems = 0;
            Debug.Log("Entregaste un item");
        }
        if(piecesFound == 5)
        {
            // Código para terminar escena
            Debug.Log("Ganaste");
        }
    }

}
