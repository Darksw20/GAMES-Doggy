using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoStopperController : GameRouting
{
    public string level;
    // Start is called before the first frame update
    public double time;
    public double currentTime;
    // Use this for initialization

    void Start()
    {
        try
        {
            AudioSource musicObject = GameObject.FindGameObjectsWithTag("GameMusic")[0].GetComponent<AudioSource>();
            musicObject.mute = !musicObject.mute;

        }
        catch (Exception e) { Debug.Log("a"+e); }
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
            currentTime = gameObject.GetComponent<VideoPlayer>().time;
        try
        {
            AudioSource musicObject = GameObject.FindGameObjectsWithTag("GameMusic")[0].GetComponent<AudioSource>();
            if (currentTime >= time || Input.GetButton("Continue"))
            {
                musicObject.mute = !musicObject.mute;
                
            }

        }
        catch (Exception e) { Debug.Log("Modo prueba Audio"+e); }

        if (currentTime >= time || Input.GetButton("Continue"))
        {
            ChooseLevel(level);
        }
    }
}
