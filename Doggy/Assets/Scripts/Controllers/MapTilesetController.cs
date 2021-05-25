using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTilesetController : MonoBehaviour
{
    public GameObject[] maps;

    // Start is called before the first frame update
    void Start()
    {
        maps[0].SetActive(true);
        maps[1].SetActive(true);
        maps[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
