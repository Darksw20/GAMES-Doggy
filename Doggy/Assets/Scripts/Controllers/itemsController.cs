using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemsController : GameRouting
{
    public GameObject lagoLleno;
    private GameObject llanta1;
    private GameObject llanta2;
    private GameObject llanta3;
    private GameObject llanta4;
    private GameObject caja;

    private GameObject _13m;
    private GameObject _14n;
    private GameObject _15o;
    private GameObject _16p;
    private GameObject _12l;
    private GameObject _11k;
    private GameObject _18s;
    private GameObject _19;
    private GameObject _17r;
    private GameObject _9i;

    private int piecesFound = 0;
    private int carryingItems = 0;

    private GameObject itemBeingCarried = null;
    
    List<string> listTubos = new List<string>(0);

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
        } else if (SceneManager.GetActiveScene().name == "Level2_2")
        {
            _13m = GameObject.Find("13m");
            _14n = GameObject.Find("14n");
            _15o = GameObject.Find("15o");
            _16p = GameObject.Find("16p");
            _12l = GameObject.Find("12l");
            _11k = GameObject.Find("11k");
            _18s = GameObject.Find("18s");
            _19 = GameObject.Find("19");
            _17r = GameObject.Find("17r");
            _9i = GameObject.Find("9i");
            lagoLleno = GameObject.Find("2-2(v2)");

            _13m.SetActive(false);
            _14n.SetActive(false);
            _15o.SetActive(false);
            _16p.SetActive(false);
            _12l.SetActive(false);
            _11k.SetActive(false);
            _18s.SetActive(false);
            _19.SetActive(false);
            _17r.SetActive(false);
            _9i.SetActive(false);
            lagoLleno.SetActive(false);
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
            if (!lvl2_1_1_shopController.hasBoughtStrenght)
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
        
        // Si el jugador compró la habilidad de fuerza
        if (lvl2_1_1_shopController.hasBoughtStrenght)
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

    public void pickTube(GameObject gameObject)
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

    public void giveItem(GameObject gameObject)
    {
        try
        {
            switch (gameObject.name)
            {
                case "1a":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("13m"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _13m.SetActive(true);
                        piecesFound++;
                        listTubos.Add("13m");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "2b":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("14n"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _14n.SetActive(true);
                        piecesFound++;
                        listTubos.Add("14n");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "3c":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("15o"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _15o.SetActive(true);
                        piecesFound++;
                        listTubos.Add("15o");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "4d":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("16p"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _16p.SetActive(true);
                        piecesFound++;
                        listTubos.Add("16p");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "6f":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("18s"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _18s.SetActive(true);
                        piecesFound++;
                        listTubos.Add("18s");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "5e":
                    if (itemBeingCarried.name == "tuboC" && !listTubos.Contains("17r"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _17r.SetActive(true);
                        piecesFound++;
                        listTubos.Add("17r");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "7g":
                    if (itemBeingCarried.name == "tuboT" && !listTubos.Contains("9i"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _9i.SetActive(true);
                        piecesFound++;
                        listTubos.Add("9i");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "8h":
                    if (itemBeingCarried.name == "tuboT" && !listTubos.Contains("19"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _19.SetActive(true);
                        piecesFound++;
                        listTubos.Add("19");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "Final1":
                    if (itemBeingCarried.name == "tuboX" && !listTubos.Contains("12l"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _12l.SetActive(true);
                        piecesFound++;
                        listTubos.Add("12l");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
                case "Final2":
                    if (itemBeingCarried.name == "tuboT" && !listTubos.Contains("11k"))
                    {
                        Destroy(itemBeingCarried);
                        carryingItems = 0;
                        _11k.SetActive(true);
                        piecesFound++;
                        listTubos.Add("11k");
                    }
                    else
                    {
                        Debug.Log("Esta pieza no va aqui");
                    }
                    break;
            }
        }
        catch (MissingReferenceException e) { Debug.Log("ya sabemos que no hay nah"+ e); }
        
        if (piecesFound == 10)
        {
            lagoLleno.SetActive(true);
            StartCoroutine(lagoLlenandose());
            
        }
    }
    IEnumerator lagoLlenandose()
    {
        yield return new WaitForSeconds(3);
        Level3_1();
    }
    public GameObject isCarrying()
    {
        return itemBeingCarried;
    }

}
