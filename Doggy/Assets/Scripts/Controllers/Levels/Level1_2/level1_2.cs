using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class level1_2 : MonoBehaviour
{
    public GameObject Ana;
    public GameObject Max;

    public GameObject _1pineCone;
    public GameObject _2pineCone;
    public GameObject _3pineCone;
    public GameObject _4pineCone;
    public GameObject _5pineCone;

    private MapTilesetController TilesetsController;

    private int mapChangeCount = 0;

    void Start()
    {
        TilesetsController = GameObject.Find("Tilesets").GetComponent<MapTilesetController>();
        InvokeRepeating("pineConesRandomPosition", 5F, 5F);
        InvokeRepeating("changeMap", 0, 20F);
    }

    void Update()
    {
        if (GameManager.instancia.time == 0)
           timeOver();
    }

    public void resetLevel()
    {
        Ana.GetComponent<Transform>().localPosition = new Vector3(-3F, 1F, 0);
        Max.GetComponent<Transform>().localPosition = new Vector3(0F, 0F, 0);
    }

    private void timeOver()
    {
        resetLevel();
        GameManager.instancia.time = 50;
        GameManager.instancia.health--;
        mapChangeCount = 0;
    }

    private void pineConesRandomPosition()
    {
        _1pineCone.GetComponent<pineCone>().changePosition();
        _2pineCone.GetComponent<pineCone>().changePosition();
        _3pineCone.GetComponent<pineCone>().changePosition();
        _4pineCone.GetComponent<pineCone>().changePosition();
        _5pineCone.GetComponent<pineCone>().changePosition();
    }

    private void changeMap()
    {
        if (mapChangeCount < 3)
        {
            TilesetsController.setRandomMap();
            GameObject.Find("AI").GetComponent<AIDestinationSetter>().target = TilesetsController.getTarget();
            mapChangeCount++;
        }
    }
}
