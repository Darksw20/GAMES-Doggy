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

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            ChooseLevel(level);
        }
    }
}
