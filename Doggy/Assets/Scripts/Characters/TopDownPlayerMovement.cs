using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 2f;
    Vector2 movement;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        if (movement.x > 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        if (movement.y < 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        if (movement.y > 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
