using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTilesetController : MonoBehaviour
{
    public GameObject _1map;
    public GameObject _2map;
    public GameObject _3map;

    void Start()
    {
        setRandomMap();
    }

    public void setRandomMap()
    {
        int num = (int)Random.Range(0.0f, 3.0f);
        switch (num.ToString())
        {
            case "0":
                _1map.SetActive(true);
                _2map.SetActive(false);
                _3map.SetActive(false);
                break;
            case "1":
                _1map.SetActive(false);
                _2map.SetActive(true);
                _3map.SetActive(false);
                break;
            case "2":
                _1map.SetActive(false);
                _2map.SetActive(false);
                _3map.SetActive(true);
                break;
        }
    }

}
