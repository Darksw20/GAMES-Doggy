using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crayola : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    public void moveObject()
    {
        mousePosition = Input.mousePosition;
        mousePosition.x += 20;
        mousePosition.y += 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
