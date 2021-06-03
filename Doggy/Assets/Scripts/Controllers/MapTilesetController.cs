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
        int num = (int)Random.Range(0.0f, 3.0f);
        Debug.Log("num: " + num);
        switch (num.ToString())
        {
            case "0":
                Debug.Log("case 0");
                _1map.SetActive(true);
                _2map.SetActive(false);
                _3map.SetActive(false);
                break;
            case "1":
                Debug.Log("case 1");
                _1map.SetActive(false);
                _2map.SetActive(true);
                _3map.SetActive(false);
                break;
            case "2":
                Debug.Log("case 2");
                _1map.SetActive(false);
                _2map.SetActive(false);
                _3map.SetActive(true);
                break;
        }
    }
}
