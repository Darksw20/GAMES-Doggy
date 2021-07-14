using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class reviewController : GameRouting
{
    
    public void addReview1()
    {
        CreateReviewFile("1");
        MainMenu();
    }

    public void addReview2()
    {
        CreateReviewFile("2");
        MainMenu();
    }
    public void addReview3()
    {
        CreateReviewFile("3");
        MainMenu();
    }
    public void addReview4()
    {
        CreateReviewFile("4");
        MainMenu();
    }
    public void addReview5()
    {
        CreateReviewFile("5");
        MainMenu();
    }

    void CreateReviewFile(string review)
    {
        //Escoge la locacion donde se guardara el texto
        string path = Application.persistentDataPath + "/Reviews.txt";
        //Crea el archivo si no existe
        if (!File.Exists(path))
        {
            File.WriteAllText(path,"Archivo de Calificaciones:\n");
        }
        string newReview = GameManager.instancia.playerName + " califica el juego con: " + review + "\n";
        File.AppendAllText(path,newReview);
        Debug.Log(path);
    }
}
