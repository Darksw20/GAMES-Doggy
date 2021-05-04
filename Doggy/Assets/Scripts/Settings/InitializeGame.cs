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
        GameManager.instancia.playerName = userName.text;
        Debug.Log("Your name is " + GameManager.instancia.playerName);

        GameRouting.Dificulties();
    }
    public void easyInitializeGame()
    {
        GameManager.instancia.time = 100;
        GameManager.instancia.dificulty = 0;
        checkInitialization();
        GameRouting.Level1_1();
    }

    public void normalInitializeGame()
    {
        GameManager.instancia.time = 60;
        GameManager.instancia.dificulty = 1;
        checkInitialization();
        GameRouting.Level1_1();
    }

    public void hardInitializeGame()
    {
        GameManager.instancia.time = 30;
        GameManager.instancia.dificulty = 2;
        checkInitialization();
        GameRouting.Level1_1();
    }

    public static void checkInitialization()
    {
        Debug.Log("Your name is " + GameManager.instancia.playerName);
        Debug.Log("Your actual level is " + GameManager.instancia.level);
        Debug.Log("Your points are " + GameManager.instancia.points);
        Debug.Log("Your Life is " + GameManager.instancia.health);
        Debug.Log("Your Money is " + GameManager.instancia.money);
        Debug.Log("Your Red Gems are " + GameManager.instancia.redJewels);
        Debug.Log("Your Blue Gems is " + GameManager.instancia.blueJewels);
        Debug.Log("Your Time is " + GameManager.instancia.time);
        Debug.Log("Your Dificulty is " + GameManager.instancia.dificulty);
    }
}
