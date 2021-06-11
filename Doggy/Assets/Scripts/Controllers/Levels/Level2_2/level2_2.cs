using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_2 : MonoBehaviour
{

    public GameObject _13m;
    public GameObject _14n;
    public GameObject _15o;
    public GameObject _16p;
    public GameObject _12l;
    public GameObject _11k;
    public GameObject _18s;
    public GameObject _19;
    public GameObject _17r;
    public GameObject _9i;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void giveItem(GameObject tuberia)
    {
        switch (tuberia.name)
        {
            case "1a":
                //_13m.SetActive(true);
                break;
        }
    }
}
