using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject circle;

    void Start()
    {
        circle.SetActive(false);
    }

    private void OnMouseEnter()
    {
        Vector3 vector3 = new Vector3(12.5F, 12.5F, 1);
        transform.localScale = vector3;
    }
    private void OnMouseExit()
    {
        Vector3 vector3 = new Vector3(10F, 10F, 1);
        transform.localScale = vector3;
    }
    public void selectItem()
    {
        circle.SetActive(true);
    }

    public void unselectItem()
    {
        circle.SetActive(false);
    }
}
