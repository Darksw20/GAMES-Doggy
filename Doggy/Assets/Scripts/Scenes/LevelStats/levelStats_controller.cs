using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelStats_controller : MonoBehaviour
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
        level.text = "misión";
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
        Debug.Log("next scene");
    }

}
