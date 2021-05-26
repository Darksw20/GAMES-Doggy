using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_1_1_itemsController : MonoBehaviour
{
    private int piecesFound = 0;
    private int carryingItems = 0;


    public void pickItem(GameObject gameObject)
    {
        // Si el jugador compró la habilidad de fuerza
        if(lvl2_1_1_shopController.getStrenght())
        {
            Destroy(gameObject);
            carryingItems++;
            Debug.Log("Recogiste un item, regrésalo al pájaro o recoje más");
        }
        else
        {
            Debug.Log("Ya estás cargando un item");
            if (carryingItems == 0)
            {
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
