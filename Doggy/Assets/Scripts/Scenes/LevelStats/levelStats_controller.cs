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

    private static string currentScene = null;

    void Start()
    {
        updateText();
    }

    private void updateText()
    {
        time.text = "Completado en:\n" + GameManager.instancia.time.ToString() + " segundos";
        level.text = getLevelText();
        health.text = GameManager.instancia.health.ToString();
        redDiamonds.text = GameManager.instancia.redJewels.ToString();
        blueDiamonds.text = GameManager.instancia.blueJewels.ToString();
        coins.text = GameManager.instancia.money.ToString();
    }

    public static void setCurrentScene(string scene)
    {
        currentScene = scene;
    }

    public void nextScene()
    {
        ChooseLevel(GameManager.instancia.nextLevel.ToString());
    }

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
                return "Level2_1_2";

            case 5:
                return "Level2_2";

            case 6:
                return "Level3_1";

            case 7:
                return "Level3_2_1";

            case 8:
                return "Level3_2_2";

            case 9:
                return "Level3_2_3";
        }
        return null;
    }

}
