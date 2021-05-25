using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTilesetController : MonoBehaviour
{
    public GameObject[] maps;

    // Start is called before the first frame update
    void Start()
    {
        int num = (int)Random.Range(0.0f, 2.0f);
        int i = (int)Random.Range(1.0f, 12.0f);
        for (;i > 0; i--)
        {
            num = (int)Random.Range(0.0f, 3.0f);
        }
        switch (num.ToString())
        {
            case "0":
                maps[0].SetActive(true);
                maps[1].SetActive(false);
                maps[2].SetActive(false);
                break;
            case "1":
                maps[0].SetActive(false);
                maps[1].SetActive(true);
                maps[2].SetActive(false);
                break;
            case "2":
                maps[0].SetActive(false);
                maps[1].SetActive(false);
                maps[2].SetActive(true);
                break;
            default:
                maps[0].SetActive(true);
                maps[1].SetActive(false);
                maps[2].SetActive(false);
                break;
        }
    }
}
