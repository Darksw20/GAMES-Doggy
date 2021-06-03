using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_2 : MonoBehaviour
{
    public GameObject Ana;
    public GameObject Max;

    public GameObject _1pineCone;
    public GameObject _2pineCone;
    public GameObject _3pineCone;
    public GameObject _4pineCone;
    public GameObject _5pineCone;

    private MapTilesetController TilesetsController = GameObject.Find("Tilesets").GetComponent<MapTilesetController>();

    void Start()
    {
        InvokeRepeating("pineConesRandomPosition", 5F, 5F);
    }

    public void resetLevel()
    {
        Ana.GetComponent<Transform>().localPosition = new Vector3(-3F, 1F, 0);
        Max.GetComponent<Transform>().localPosition = new Vector3(-3.75F, 1F, 0);
        TilesetsController.setRandomMap();
    }

    private void pineConesRandomPosition()
    {
        _1pineCone.GetComponent<pineCone>().changePosition();
        _2pineCone.GetComponent<pineCone>().changePosition();
        _3pineCone.GetComponent<pineCone>().changePosition();
        _4pineCone.GetComponent<pineCone>().changePosition();
        _5pineCone.GetComponent<pineCone>().changePosition();
    }
}
