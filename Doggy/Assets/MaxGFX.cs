using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MaxGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01F)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 0f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01F)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(-1f, 1f, 0f);
        }
        else if (aiPath.desiredVelocity.y <= 0.01F)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(1f, -1f, 0f);
        }
        else if (aiPath.desiredVelocity.y >= -0.01F)
        {
            GetComponentInChildren<Transform>().localScale = new Vector3(1f, 1f, 0f);
        }
    }
}
