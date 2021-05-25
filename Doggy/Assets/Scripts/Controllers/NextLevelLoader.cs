using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : GameRouting
{
    public string level;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.transform.tag == "GameLoader")
        {
            ChooseLevel(level);
        }
    }
}
