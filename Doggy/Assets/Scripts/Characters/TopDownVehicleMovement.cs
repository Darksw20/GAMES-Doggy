using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownVehicleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        movement.x = 0.1F;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
