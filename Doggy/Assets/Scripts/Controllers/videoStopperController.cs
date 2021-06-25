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
        AudioSource musicObject = GameObject.FindGameObjectsWithTag("GameMusic")[0].GetComponent<AudioSource>();
        musicObject.mute = !musicObject.mute;
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        AudioSource musicObject = GameObject.FindGameObjectsWithTag("GameMusic")[0].GetComponent<AudioSource>();

        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            musicObject.mute = !musicObject.mute;
            ChooseLevel(level);
        }
    }
}
