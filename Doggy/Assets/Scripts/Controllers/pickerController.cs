using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickerController : MonoBehaviour
{
    public Object controller;
    private itemsController itemsController;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level2_1_1" ||
            SceneManager.GetActiveScene().name == "Level2_2")
        {
            controller = GetComponent<itemsController>();
            itemsController = (itemsController)controller;
        }
    }

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

            case "Tubo":
                itemsController.pickItem(other.gameObject);
                break;

            case "PajaroCarpinteroLvl2_1_1":
                itemsController.giveItem();
                break;

            case "CarroLvl_2_1_1":
                itemsController.pickItem(other.gameObject);
                break;

            case "FinalJuego":
                //aqui se hace ese codigo
                Debug.Log("Se acabo el juego mije");
                break;

            case null:
                Debug.Log(other.GetType().ToString());
                break;
        }
    }
}
