using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_2_shopController : MonoBehaviour
{
    public Rigidbody2D rb;

    private bool hasBoughtRun = false;

    void Update()
    {
        if (Input.GetButton("1"))
        {
            if (GameManager.instancia.galletas > 0 && !hasBoughtRun)
            {
                GameManager.instancia.galletas--;
                rb.GetComponent<TopDownPlayerMovement>().setMoveSpeed(4f);
            }
        }

        if (Input.GetButton("2"))
        {
            if (GameManager.instancia.galletas > 0)
            {
                GameManager.instancia.galletas--;
                GameManager.instancia.time += 5;
            }
        }
    }
}
