using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRouting : MonoBehaviour
{
    
    public void QuitGameSequence()
    {
        Application.Quit();
    }

    public static void Dificulties()
    {
        SceneManager.LoadScene("Dificulty");
    }

    public void Disclaimer()
    {
        SceneManager.LoadScene("Disclaimer");
    }

    public void Anim_adoption()
    {
        SceneManager.LoadScene("Anim_adoption");
    }

    public void Anim_construction()
    {
        SceneManager.LoadScene("Anim_construccion");
    }
    public void Anim_credits()
    {
        SceneManager.LoadScene("Anim_credits");
    }
    public void Anim_Fin()
    {
        SceneManager.LoadScene("Anim_Fin");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NewGame()
    {
        // Aqui creo un personaje
        SceneManager.LoadScene("NewGame");
        //Destroy(GameObject.Find("Audio Source"));
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
        //Destroy(GameObject.Find("Audio Source"));
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void Sound()
    {
        SceneManager.LoadScene("Sound");
    }

    public static void Level1_1()
    {
        //Aqui debe estar la logica de crear nuevo personaje
        SceneManager.LoadScene("Level1_1");
    }
    public void Level1_2()
    {
        SceneManager.LoadScene("Level1_2");
    }
    public void Level2_1_1()
    {
        SceneManager.LoadScene("Level2_1_1");
    }
    public void Level2_1_2()
    {
        SceneManager.LoadScene("Level2_1_2");
    }
    public static void Level2_2()
    {
        SceneManager.LoadScene("Level2_2");
    }
    public void Level3_1()
    {
        SceneManager.LoadScene("Level3_1");
    }
    public void Level3_2_1()
    {
        SceneManager.LoadScene("Level3_2_1");
    }
    public void Level3_2_2()
    {
        SceneManager.LoadScene("Level3_2_2");
    }
    public void Level3_2_3()
    {
        SceneManager.LoadScene("Level3_2_3");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("LevelStats");
    }

    public void ChooseLevel(string level)
    {
        switch (level)
        {
            case "1":
                Level1_1();
                break;

            case "2":
                Level1_2();
                break;

            case "3":
                Level2_1_1();
                break;

            case "4":
                Level2_1_2();
                break;

            case "5":
                Level2_2();
                break;

            case "6":
                Level3_1();
                break;

            case "7":
                Level3_2_1();
                break;

            case "8":
                Level3_2_2();
                break;

            case "9":
                Level3_2_3();
                break;

            case "10":
                Anim_construction();
                break;

            case "11":
                Anim_Fin();
                break;

            case "Menu":
                MainMenu();
                break;
        }
    }   
}
