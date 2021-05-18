using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instancia.BeginGame();
        Debug.Log("Juego cargado correctamente");
        SceneManager.LoadScene("Menu");
    }
}
