using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickerController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Coin":
                GameManager.instancia.money++;
                Destroy(other.gameObject);
                break;

            case "MysteryBox":
                int num = (int)(Random.Range(1.0f, 2.0f) * 1000);
                if (num % 2 == 1)
                {
                    GameManager.instancia.redJewels++;
                    Destroy(other.gameObject);
                }
                else if (num % 2 == 0)
                {
                    GameManager.instancia.blueJewels++;
                    Destroy(other.gameObject);
                }
                break;

            case "Galleta":
                GameManager.instancia.galletas++;
                Destroy(other.gameObject);
                break;
        }
    }
}
