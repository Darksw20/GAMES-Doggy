using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : GameRouting
{
    public int level;
    public int nextLvl;

    void Start()
    {
        GameManager.instancia.level = level;    
        GameManager.instancia.nextLevel = nextLvl;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //reviso si la colision la ocasiono un GameLoader
        if(other.transform.tag == "GameLoader")
        {
            // Y el nivel es el nivel 1 y tienes las 3 galletas
            if (SceneManager.GetActiveScene().name == "Level1_1" &&
                GameManager.instancia.galletas == 3)
            {
                //Guardo el nivel
                SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                //Paso al siguiente nivel
                nextLevel();
            }
            // Si el nivel es el 1.2
            if (SceneManager.GetActiveScene().name == "Level1_2")
            {
                //Guardo el nivel
                SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                //Paso al siguiente nivel
                nextLevel();
            }
            
        }else if(other.transform.tag == "Die")
        {

        }
    }
}
