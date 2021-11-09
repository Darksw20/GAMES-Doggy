using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : GameRouting
{
    public void clickLoad1()
    {
        LoadGame(0);//hola
    }

    public void clickLoad2()
    {
        LoadGame(1);
    }

    public void clickLoad3()
    {
        LoadGame(2);
    }

    public void LoadGame(int saveSlot)
    {
        GameData data = SaveSystem.LoadGameData(saveSlot);

        GameManager.instancia.playerName = data.playerName;
        GameManager.instancia.level = data.level;
        GameManager.instancia.points = data.points;
        GameManager.instancia.galletas = data.galletas;
        GameManager.instancia.health = data.health;
        GameManager.instancia.money = data.money;
        GameManager.instancia.redJewels = data.redJewels;
        GameManager.instancia.blueJewels = data.blueJewels;
        GameManager.instancia.time = data.time;
        GameManager.instancia.dificulty = data.dificulty;
        GameManager.instancia.isMusicOn = data.isMusicOn;
        GameManager.instancia.saveSlot = data.saveSlot;

        GameManager.instancia.VisualizeData();

        ChooseLevel(GameManager.instancia.level++.ToString());


    }
}
