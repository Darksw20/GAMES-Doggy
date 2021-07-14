using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelStats_controller : GameRouting
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI level;
    public TextMeshProUGUI health;
    public TextMeshProUGUI redDiamonds;
    public TextMeshProUGUI blueDiamonds;
    public TextMeshProUGUI coins;

    public Sprite missionCompleted;
    public Sprite levelCompleted;

    public GameObject backgroundImage;

    void Start()
    {
        showImage();
    }

    private void showImage()
    {
        //Verifico el nivel donde se encuentra el jugador
        //y le muestro la pantalla corrrespondiente
        int level = GameManager.instancia.level;
        if (level == 1 || level == 3 || level == 4 || level == 6 || level == 7 || level == 8)
        {
            backgroundImage.GetComponent<SpriteRenderer>().sprite = missionCompleted;
        } else if (level == 2 || level == 5 || level == 9)
        {
            backgroundImage.GetComponent<SpriteRenderer>().sprite = levelCompleted;
        }
        //Le damos al jugador una recompesa en joyas
        GameManager.instancia.blueJewels += 2;
        GameManager.instancia.redJewels += 2;
        
        //Quita la imagen
        StartCoroutine(removeImage());
    }
    //Cambia los datos de la pantalla con los datos 
    //de los items que conseguiste en ese nivel
    private void updateText()
    {
        //Reviso en cuanto tiempo se completo el juego
        time.text = "Completado en:\n" + (GameManager.instancia.levelTime-GameManager.instancia.time) + " segundos";
        level.text = getLevelText();
        health.text = GameManager.instancia.health.ToString();
        redDiamonds.text = GameManager.instancia.redJewels.ToString();
        blueDiamonds.text = GameManager.instancia.blueJewels.ToString();
        coins.text = GameManager.instancia.money.ToString();
    }
    public void nextScene()
    {
        ChooseLevel(GameManager.instancia.nextLevel.ToString());
    }

    //Me dice en texto cual es el nivel que jugue
    private string getLevelText()
    {
        switch (GameManager.instancia.level)
        {
            case 1:
                return "Level1_1";

            case 2:
                return "Level1_2";

            case 3:
                return "Level2_1_1";

            case 4:
                return "Anim_construction";

            case 5:
                return "Level2_1_2";

            case 6:
                return "Level2_2";

            case 7:
                return "Level3_1";

            case 8:
                return "Level3_2_1";

            case 9:
                return "Level3_2_2";

            case 10:
                return "Level3_2_3";
            case 11:
                return "Anim_Fin";
            
        }
        return null;
    }
    //Quita la imagen espera 3 segundos y modifica los datos en pantalla

    IEnumerator removeImage()
    {
        yield return new WaitForSeconds(3);
        backgroundImage.GetComponent<SpriteRenderer>().sprite = null;
        updateText();
    }

}
