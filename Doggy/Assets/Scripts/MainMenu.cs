using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("NewGame");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void Sound()
    {
        SceneManager.LoadScene("Sound");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
