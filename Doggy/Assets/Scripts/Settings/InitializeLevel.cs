using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeLevel : MonoBehaviour
{
    public void easyInitializeGame()
    {
        PlayerPrefs.SetInt("Time", 0);
        PlayerPrefs.SetInt("Dificulty", 0);
        checkInitialization();
        GameRouting.Level1_1();
    }

    public void normalInitializeGame()
    {
        PlayerPrefs.SetInt("Time", 0);
        PlayerPrefs.SetInt("Dificulty", 1);
        checkInitialization();
        GameRouting.Level1_1();
    }

    public void hardInitializeGame()
    {
        PlayerPrefs.SetInt("Time", 0);
        PlayerPrefs.SetInt("Dificulty", 2);
        checkInitialization();
        GameRouting.Level1_1();
    }

    public static void checkInitialization()
    {
        Debug.Log("Your name is " + PlayerPrefs.GetString("PlayerName"));
        Debug.Log("Your actual level is " + PlayerPrefs.GetInt("Level"));
        Debug.Log("Your points are " + PlayerPrefs.GetInt("Points"));
        Debug.Log("Your Life is " + PlayerPrefs.GetInt("Life"));
        Debug.Log("Your Money is " + PlayerPrefs.GetInt("Money"));
        Debug.Log("Your Red Gems are " + PlayerPrefs.GetInt("Red"));
        Debug.Log("Your Blue Gems is " + PlayerPrefs.GetInt("Blue"));
        Debug.Log("Your Time is " + PlayerPrefs.GetInt("Time"));
        Debug.Log("Your Dificulty is " + PlayerPrefs.GetInt("Dificulty"));
    }
}
