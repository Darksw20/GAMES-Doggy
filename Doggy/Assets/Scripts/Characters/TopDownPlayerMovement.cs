using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 2f;

    private Vector2 movement;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Izquierda
        if (movement.x < 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        //Derecha
        if (movement.x > 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //Abajo
        if (movement.y < 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        //Arriba
        if (movement.y > 0)
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);

        if (SceneManager.GetActiveScene().name == "Level2_2" && Input.GetMouseButtonDown(0))
        {
            if (GetComponent<itemsController>().isCarrying() != null)
            {
                GameObject item = GetComponent<itemsController>().isCarrying();
                if (item.transform.localScale == new Vector3(0.5F, 0.5F, 0))            
                {
                    item.transform.localScale = new Vector3(0.5F, -0.5F, 0);
                } else if (item.transform.localScale == new Vector3(0.5F, -0.5F, 0))
                {
                    item.transform.localScale = new Vector3(-0.5F, 0.5F, 0);
                } else if (item.transform.localScale == new Vector3(-0.5F, 0.5F, 0))
                {
                    item.transform.localScale = new Vector3(-0.5F, -0.5F, 0);
                } else if (item.transform.localScale == new Vector3(-0.5F, -0.5F, 0))
                {
                    item.transform.localScale = new Vector3(0.5F, 0.5F, 0);
                }
            }
        }
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
