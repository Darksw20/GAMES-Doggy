using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeController : MonoBehaviour
{
    public float initialTime;                   //Valor inicial default del timer
    public static float timeRemaining;          //Contador de tiempo
    public static bool timerIsRunning = false;  //Un verificador de si el tiempo esta corriendo

    private void Start()
    {
        //verifica la dificultad y voy a ajusto el tiempo inicial
        switch (GameManager.instancia.dificulty)
        {
            //dificultad facil
            case 0:
                initialTime += 10;
                break;
            //dificultad dificil
            case 2:
                initialTime -= 10;
                break;
            //dificultad normal
            default:
                break;

        }
        //inicializo el contador con el initialTime
        timeRemaining = initialTime;
        //Guardo en el Singleton el tiempo del nivel
        GameManager.instancia.levelTime = (int)timeRemaining;
        GameManager.instancia.time = (int)timeRemaining;
    }

    void Update()
    {
        // Valido si el tiempo debe estar corriendo
        if (timerIsRunning)
        {
            // Verifico si el contador ha llegado a cero
            if (GameManager.instancia.time > 0)
            {
                //Si el tiempo es mayor, sigo actualizando el 
                //contador
                timeRemaining -= Time.deltaTime;
                GameManager.instancia.time = (int)timeRemaining;
            }
            else
            {
                //Si no, enviamos al jugador a la escena de muerte
                //y reseteamos los valores de tiempo para que no
                //se loopie
                SceneManager.LoadScene("Death");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    //Al activar, se suman 5 segundos al contador
    public static void ability5sec()
    {
        timeRemaining += 5;
    }
    //Para el tiempo
    public static void stopTime()
    {
        timerIsRunning = false;
    }
    //Continua el tiempo
    public static void continueTime()
    {
        timerIsRunning = true;
    }
}
