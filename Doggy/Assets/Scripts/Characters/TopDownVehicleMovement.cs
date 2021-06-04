using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownVehicleMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with object
        if (collision.gameObject.name == "rayon")
        {
            GameManager.instancia.health--;
            SceneManager.LoadScene("Level3_2_3");
        }
    }

    public void moveObject(Vector2 movement)
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
