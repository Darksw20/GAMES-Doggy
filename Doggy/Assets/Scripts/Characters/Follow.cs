using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject max;

    private Rigidbody2D maxRB;

    void Start()
    {
        maxRB = GetComponent<Rigidbody2D>();
    }

    public Rigidbody2D getMaxRigidBody()
    {
        return maxRB;
    }

}
