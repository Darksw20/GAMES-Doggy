using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    const int MUSIC_ON = 1;
    const int MUSIC_OFF = 0;

    public Toggle audioToggle;
    public void ToggleMusic()
    {
        Debug.Log(""+ audioToggle.isOn);
        if(GameManager.instancia.isMusicOn == MUSIC_ON) // si no esta pausado, lo pausas
        {
            GameManager.instancia.isMusicOn = MUSIC_OFF;
            AudioListener.pause = true;
        }
        else if(GameManager.instancia.isMusicOn == MUSIC_OFF)
        {
            GameManager.instancia.isMusicOn = MUSIC_ON;
            AudioListener.pause = false; //lo mantienes sin pausar o lo despausas
        }
    }

    private void Start()
    {
        if (GameManager.instancia.isMusicOn == MUSIC_ON)
        {
            audioToggle.isOn = true;
            AudioListener.pause = false;
            Debug.Log("check prendido --");
        }
        else if (GameManager.instancia.isMusicOn == MUSIC_OFF)
        {
            audioToggle.isOn = false;
            AudioListener.pause = true;
            Debug.Log("check apagado --");
        }
    }
    
}

