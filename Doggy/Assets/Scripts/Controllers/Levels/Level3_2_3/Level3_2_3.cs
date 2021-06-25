using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_2_3 : MonoBehaviour
{
    public Sprite Rayon_rojo;

    public GameObject Vehicle;
    public GameObject Crayola;

    private Vector2 movement;

    void Start()
    {
        movement.x = 0.1F;
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical") / 10;
        Crayola.GetComponent<Crayola>().moveObject();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag == "BacheLvl3_2_3")
            {
                clickObject(hit.collider.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        Vehicle.GetComponent<TopDownVehicleMovement>().moveObject(movement);
    }

    private void clickObject(GameObject gameObject)
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Rayon_rojo;
        gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}
