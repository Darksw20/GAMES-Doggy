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
        if(other.transform.tag == "GameLoader")
        {
            if (SceneManager.GetActiveScene().name == "Level1_1" &&
                GameManager.instancia.galletas == 3)
            {
                SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                nextLevel();
            }
            if (SceneManager.GetActiveScene().name == "Level1_2")
            {
                SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
                nextLevel();
            }
            
        }else if(other.transform.tag == "Die")
        {

        }
    }
}
