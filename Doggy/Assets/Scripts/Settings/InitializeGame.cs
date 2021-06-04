using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitializeGame : MonoBehaviour
{
    public TMP_InputField userName;
    public void clickSaveButton()
    {
        GameManager.instancia.playerName = userName.text == null || userName.text == "" ? "Ana" : userName.text;
        Debug.Log("Your name is " + GameManager.instancia.playerName);

        GameRouting.Dificulties();
    }
    public void easyInitializeGame()
    {
        GameManager.instancia.saveSlot = 0;
        GameManager.instancia.time = 100;
        GameManager.instancia.dificulty = 0;
        GameManager.instancia.VisualizeData();
        GameRouting.Level1_1();
    }

    public void normalInitializeGame()
    {
        GameManager.instancia.saveSlot = 1;
        GameManager.instancia.time = 60;
        GameManager.instancia.dificulty = 1;
        GameManager.instancia.VisualizeData();
        GameRouting.Level1_1();
    }

    public void hardInitializeGame()
    {
        GameManager.instancia.saveSlot = 2;
        GameManager.instancia.time = 30;
        GameManager.instancia.dificulty = 2;
        GameManager.instancia.VisualizeData();
        GameRouting.Level1_1();
    }

}
