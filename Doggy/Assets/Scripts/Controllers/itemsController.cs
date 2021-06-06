using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemsController : GameRouting
{

    private GameObject llanta1;
    private GameObject llanta2;
    private GameObject llanta3;
    private GameObject llanta4;
    private GameObject caja;

    private int piecesFound = 0;
    private int carryingItems = 0;

    private GameObject itemBeingCarried = null;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level2_1_1")
        {
            llanta1 = GameObject.Find("hud_llanta1");
            llanta2 = GameObject.Find("hud_llanta2");
            llanta3 = GameObject.Find("hud_llanta3");
            llanta4 = GameObject.Find("hud_llanta4");
            caja = GameObject.Find("hud_box");
            llanta1.SetActive(false);
            llanta2.SetActive(false);
            llanta3.SetActive(false);
            llanta4.SetActive(false);
            caja.SetActive(false);
        }
    }

    void Update()
    {
        if (itemBeingCarried != null)
        {
            followCharacter(itemBeingCarried);
        }
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
        if (type == "box")
        {
            caja.SetActive(true);
        }
        else
        {
            if (!lvl2_1_1_shopController.getStrenght())
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

    private void followCharacter(GameObject gameObject)
    {
        float rotation = transform.rotation.z;
        // Derecha
        if (rotation == 0)
        {
            gameObject.transform.position = new Vector3(transform.position.x + 0.50F,
                                                        transform.position.y,
                                                        0F);
        }
        // Izquierda
        if (rotation == 1)
        {
            gameObject.transform.position = new Vector3(transform.position.x - 0.50F,
                                                        transform.position.y,
                                                        0F);
        }
        // Arriba
        if (rotation == 0.7071068F)
        {
            gameObject.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y + 0.50F,
                                                        0F);
        }
        // Abajo
        if (rotation == -0.7071068F)
        {
            gameObject.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y - 0.50F,
                                                        0F);
        }
    }

    public void pickItem(GameObject gameObject)
    {
        if (SceneManager.GetActiveScene().name == "Level2_1_1")
        {
            // Si el jugador compró la habilidad de fuerza
            if (lvl2_1_1_shopController.getStrenght())
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
        } else if (SceneManager.GetActiveScene().name == "Level2_2")
        {
            if (carryingItems == 0)
            {
                carryingItems++;
                Vector3 scale = new Vector3(0.5F, 0.5F, 0);
                gameObject.transform.localScale = scale;
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                itemBeingCarried = gameObject;
            }
            else
            {
                Debug.Log("Ya estás cargando un item");
            }
        }
    }

    public void giveItem()
    {
        if (carryingItems != 0)
        {
            removeItem();
            piecesFound += carryingItems;
            carryingItems = 0;
            Debug.Log("Entregaste un item");
        }
        if (piecesFound == 5)
        {
            GameManager.instancia.level = 3;
            GameManager.instancia.nextLevel = 10;
            nextLevel();
        }
    }

    public GameObject isCarrying()
    {
        return itemBeingCarried;
    }

}
