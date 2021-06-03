using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_2 : MonoBehaviour
{
    public GameObject Ana;

    public GameObject _1pineCone;
    public GameObject _2pineCone;
    public GameObject _3pineCone;
    public GameObject _4pineCone;
    public GameObject _5pineCone;

    void Start()
    {
        InvokeRepeating("pineConesRandomPosition", 5F, 5F);
    }

    public void resetLevel()
    {
        
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
