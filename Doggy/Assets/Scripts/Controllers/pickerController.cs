using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickerController : GameRouting
{
    public Object controller;
    private itemsController itemsController;
    private level2_2 lvl22Controller;
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
                if (GameManager.instancia.money == 14)
                {
                    GameManager.instancia.health++;
                    GameManager.instancia.money = 0;
                }
                else
                {
                    GameManager.instancia.money++;
                }
                Destroy(other.gameObject);
                break;

            case "BacheLvl2_1_2":
                GameManager.instancia.isRotating = true;
                if (GameManager.instancia.health > 0)
                {
                    GameManager.instancia.health--;
                    Destroy(other.gameObject);
                }
                else
                {
                    SceneManager.LoadScene("Death");
                }

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
                if(GameManager.instancia.laps == 2)
                {
                    //Guardo el nivel
                    GameManager.instancia.level = 5;
                    GameManager.instancia.nextLevel = 6;
                    SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                    nextLevel();
                }
                break;

            case "TuboEn3":
                Debug.Log("Agarraste un Tubo en 3");
                itemsController.pickTube(other.gameObject);
                break;

            case "TuboL":
                Debug.Log("Agarraste un Tubo en L");
                itemsController.pickTube(other.gameObject);
                break;

            case "TuboEnX":
                Debug.Log("Agarraste un Tubo en X");
                itemsController.pickTube(other.gameObject);
                break;

            case "TuboEstatico3":
                Debug.Log("Agarraste un Tubo en 3");
                itemsController.giveItem(other.gameObject);
                break;

            case "TuboEstaticoL":
                Debug.Log("Agarraste un Tubo en L");
                itemsController.giveItem(other.gameObject);
                break;

            case "TuboEstaticoX":
                Debug.Log("Agarraste un Tubo en X");
                itemsController.giveItem(other.gameObject);
                break;

            case "PajaroCarpinteroLvl2_1_1":
                itemsController.giveItem();
                break;

            case "CarroLvl_2_1_1":
                itemsController.pickItem(other.gameObject);
                break;

            case "FinalJuego":
                GameManager.instancia.level = 10;
                GameManager.instancia.nextLevel = 11;
                //Guardo el nivel
                SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                nextLevel();
                break;

            case null:
                Debug.Log(other.GetType().ToString());
                break;
        }
    }
    

}
