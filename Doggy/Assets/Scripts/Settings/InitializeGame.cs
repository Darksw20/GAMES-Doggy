using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitializeGame : GameRouting
{
    public TMP_InputField userName;
    public void clickSaveButton()
    {
        GameManager.instancia.playerName = (userName.text.Length < 1 ||
            userName.text.Length > 15) || userName.text == null || userName.text == "" ?
            "Error" : char.ToUpper(userName.text[0]) + userName.text.Substring(1);
        Debug.Log("Your name is " + GameManager.instancia.playerName);

        Dificulties();
    }
    public void easyInitializeGame()
    {
        GameManager.instancia.saveSlot = 0;
        GameManager.instancia.nextLevel = 2;
        GameManager.instancia.time = 100;
        GameManager.instancia.dificulty = 0;
        GameManager.instancia.VisualizeData();
        Anim_adoption();
    }

    public void normalInitializeGame()
    {
        GameManager.instancia.saveSlot = 1;
        GameManager.instancia.nextLevel = 2;
        GameManager.instancia.time = 60;
        GameManager.instancia.dificulty = 1;
        GameManager.instancia.VisualizeData();
        Anim_adoption();
    }

    public void hardInitializeGame()
    {
        GameManager.instancia.saveSlot = 2;
        GameManager.instancia.nextLevel = 2;
        GameManager.instancia.time = 30;
        GameManager.instancia.dificulty = 2;
        GameManager.instancia.VisualizeData();
        Anim_adoption();
    }

}
