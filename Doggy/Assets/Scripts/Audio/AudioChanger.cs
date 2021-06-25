using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    public new AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource musicObject = GameObject.FindGameObjectsWithTag("GameMusic")[0].GetComponent<AudioSource>();
        musicObject.Pause();
        musicObject.clip = audio;
        musicObject.Play();
    }

}
