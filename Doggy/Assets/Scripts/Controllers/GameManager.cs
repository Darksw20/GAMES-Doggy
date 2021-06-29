using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ------------------------
    // Atributos estaticos
    // ------------------------
    public string playerName;
    public int level;
    public int nextLevel;
    public int points;
    public int galletas;
    public int health;
    public int money;
    public int redJewels;
    public int blueJewels;
    public int time;
    public int levelTime;
    public int dificulty;
    public int isMusicOn;
    public int saveSlot;
    public int laps;
    public bool isRotating;

    public int hSlot1;
    public int hSlot2;
    public int hSlot3;
    public int hSlot4;
    public int hSlot5;
    //att privado (_instancia)
    static private GameManager _instancia;

    //att publico (instancia) por el que accedemos
    static public GameManager instancia
    {
        // metodo get
        // se ejecuta al acceder por GameManager.instancia
        get
        {
            // si es la primera vez que accedemos a la instancia del GameManager,
            // no existira, y la crearemos
            if (_instancia == null)
            {
                // creamos un nuevo objeto llamado "_MiGameManager"
                GameObject go = new GameObject("_MiGameManager");

                // anadimos el script "GameManager" al objeto
                go.AddComponent<GameManager>();

                // guardamos en la instancia el objeto creado
                // debemos guardar el componente ya que _instancia es del tipo GameManager
                _instancia = go.GetComponent<GameManager>();
                
                // hacemos que el objeto no se elimine al cambiar de escena
                DontDestroyOnLoad(go);
            }

            // devolvemos la instancia
            // si no existia, en este punto ya la habra creado
            return _instancia;
        }

        // metodo set
        // no implementado para no permitir modificar la instancia "GameManager.instancia = x;"
    }

    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() { }

    public void BeginGame()
    {
        // Aqui se inicia cargando configuraciones globales o setteando valores
        isMusicOn = 1;
        
        playerName = "";
        level = 1;
        nextLevel = 2;
        points = 0;
        galletas = 0;
        health = 3;
        money = 0;
        redJewels = 0;
        blueJewels = 0;
        dificulty = 0;
        saveSlot = 0;
        laps = 0;
        isRotating = false;

        hSlot1 = 0;
        hSlot2 = 0;
        hSlot3 = 0;
        hSlot4 = 0;
        hSlot5 = 0;
}

    public void VisualizeData()
    {
        Debug.Log("Your name is " + _instancia.playerName);
        Debug.Log("Your actual level is " + _instancia.level);
        Debug.Log("Your points are " + _instancia.points);
        Debug.Log("Your Life is " + _instancia.health);
        Debug.Log("Your Money is " + _instancia.money);
        Debug.Log("Your Red Gems are " + _instancia.redJewels);
        Debug.Log("Your Blue Gems is " + _instancia.blueJewels);
        Debug.Log("Your Time is " + _instancia.time);
        Debug.Log("Your Dificulty is " + _instancia.dificulty);
        Debug.Log("Your Save Slot is " + _instancia.saveSlot);
        Debug.Log("Your Laps are " + _instancia.laps);

    }
}
