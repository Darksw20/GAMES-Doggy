using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public void SetMusic()
    {
        if(AudioListener.pause == false)
        {
            AudioListener.pause = true;
        } else
        {
            AudioListener.pause = false;
        }
    }
}
