using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public string playerName;
    public int level;
    public int points;
    public int galletas;
    public int health;
    public int money;
    public int redJewels;
    public int blueJewels;
    public int time;
    public int dificulty;
    public int isMusicOn;
    public int saveSlot;

    public GameData()
    {
        playerName = GameManager.instancia.playerName;
        level = GameManager.instancia.level;
        points = GameManager.instancia.points;
        galletas = GameManager.instancia.galletas;
        health = GameManager.instancia.health;
        money = GameManager.instancia.money;
        redJewels = GameManager.instancia.redJewels;
        blueJewels = GameManager.instancia.blueJewels;
        time = GameManager.instancia.time;
        dificulty = GameManager.instancia.dificulty;
        isMusicOn = GameManager.instancia.isMusicOn;
        saveSlot = GameManager.instancia.saveSlot;
    }
}
