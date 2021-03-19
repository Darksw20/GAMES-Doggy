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
        PlayerPrefs.SetString("PlayerName", userName.text);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.SetInt("Life", 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Red", 0);
        PlayerPrefs.SetInt("Blue", 0);
        
        Debug.Log("Your name is " + PlayerPrefs.GetString("PlayerName"));

        GameRouting.Dificulties();
    }
}
