using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownVehicleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rigidbody;
    private Vector2 movement;

    void Start()
    {
        movement.x = 0.1F;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
