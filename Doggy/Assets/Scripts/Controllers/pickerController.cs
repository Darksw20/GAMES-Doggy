using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickerController : GameRouting
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

            case "Meta":
                GameManager.instancia.laps++;
                Debug.Log("Vuelta "+GameManager.instancia.laps.ToString()+" completada");
                if(GameManager.instancia.laps == 7)
                {
                    GameRouting.Level2_2();
                }
                break;

            case "TuboEn3":
                Debug.Log("Agarraste un Tubo en 3");
                itemsController.pickItem(other.gameObject, "TuboEn3");
                break;

            case "TuboL":
                Debug.Log("Agarraste un Tubo en L");
                itemsController.pickItem(other.gameObject, "TuboL");
                break;

            case "TuboEnX":
                Debug.Log("Agarraste un Tubo en X");
                itemsController.pickItem(other.gameObject, "TuboEnX");
                break;

            case "TuboEstatico3":
                Debug.Log("Agarraste un Tubo en 3");
                itemsController.pickItem(other.gameObject, "TuboEn3");
                break;

            case "TuboEstaticoL":
                Debug.Log("Agarraste un Tubo en L");
                itemsController.pickItem(other.gameObject, "TuboL");
                break;

            case "TuboEstaticoX":
                Debug.Log("Agarraste un Tubo en X");
                itemsController.pickItem(other.gameObject, "TuboEnX");
                break;

            case "PajaroCarpinteroLvl2_1_1":
                itemsController.giveItem();
                break;

            case "CarroLvl_2_1_1":
                itemsController.pickItem(other.gameObject);
                break;

            case "FinalJuego":
                Anim_Fin();
                Debug.Log("Se acabo el juego mije");
                break;

            case null:
                Debug.Log(other.GetType().ToString());
                break;
        }
    }
}
