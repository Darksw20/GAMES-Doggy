using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_2_1_controller : GameRouting
{
    private GameObject circle1;
    private GameObject circle2;
    private GameObject circle3;
    private GameObject circle4;
    private GameObject circle5;

    private GameObject object1;
    private GameObject object2;
    private GameObject object3;
    private GameObject object4;
    private GameObject object5;

    private bool shouldSeeCircles = false;
    private int differencesFound = 0;

    void Start()
    {
        circle1 = GameObject.Find("circulo1");
        circle2 = GameObject.Find("circulo2");
        circle3 = GameObject.Find("circulo3");
        circle4 = GameObject.Find("circulo4");
        circle5 = GameObject.Find("circulo5");

        object1 = GameObject.Find("object1");
        object2 = GameObject.Find("object2");
        object3 = GameObject.Find("object3");
        object4 = GameObject.Find("object4");
        object5 = GameObject.Find("object5");

        resetLevel();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                foundDifference(hit.collider.gameObject);
            }
        }

        if (GameManager.instancia.time == 0)
            resetLevel();
    }
    private void resetLevel()
    {
        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);
        object4.SetActive(true);
        object5.SetActive(true);

        circle1.GetComponent<SpriteRenderer>().enabled = false;
        circle2.GetComponent<SpriteRenderer>().enabled = false;
        circle3.GetComponent<SpriteRenderer>().enabled = false;
        circle4.GetComponent<SpriteRenderer>().enabled = false;
        circle5.GetComponent<SpriteRenderer>().enabled = false;

        differencesFound = 0;
        GameManager.instancia.time = 40;
    }

    private void foundDifference(GameObject gameObject)
    {
        differencesFound++;
        switch(gameObject.name)
        {
            case "object1":
                object1.SetActive(false);
                circle1.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "object2":
                object2.SetActive(false);
                circle2.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "object3":
                object3.SetActive(false);
                circle3.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "object4":
                object4.SetActive(false);
                circle4.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "object5":
                object5.SetActive(false);
                circle5.GetComponent<SpriteRenderer>().enabled = true;
                break;
        }
        if (differencesFound == 5)
        {
            GameManager.instancia.level = 8;
            GameManager.instancia.nextLevel = 9;
            //Guardo el nivel
            SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
            nextLevel();
        }
    }

    public void setShouldSeeCircles(bool shouldSee)
    {
        shouldSeeCircles = shouldSee;
        if (shouldSeeCircles)
        {
            circle1.GetComponent<SpriteRenderer>().enabled = true;
            circle2.GetComponent<SpriteRenderer>().enabled = true;
            circle3.GetComponent<SpriteRenderer>().enabled = true;
            circle4.GetComponent<SpriteRenderer>().enabled = true;
            circle5.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public bool getShouldSeeCircles()
    {
        return shouldSeeCircles;
    }
}
