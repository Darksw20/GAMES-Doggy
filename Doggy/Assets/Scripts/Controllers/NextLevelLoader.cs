using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : GameRouting
{
    public int level;
    public int nextLevel;

    void Start()
    {
        GameManager.instancia.level = level;    
        GameManager.instancia.nextLevel = nextLevel;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "GameLoader")
        {
            SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
            GameManager.instancia.VisualizeData();
            nextLevel();
        }else if(other.transform.tag == "Die")
        {

        }
    }
}
