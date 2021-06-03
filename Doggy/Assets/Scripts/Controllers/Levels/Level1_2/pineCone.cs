using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineCone : MonoBehaviour
{
    private bool collisionDetection = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mapa")
        {
            collisionDetection = false;
            changePosition();
        } else if (collision.gameObject.tag == "Player")
        {
            GameManager.instancia.health--;
            GameObject.Find("Maps").GetComponent<level1_2>().resetLevel();
        }
    }

    public void changePosition()
    {
        float y = Random.Range(-3.5F, 4.5F);
        transform.localPosition = new Vector3(Random.Range(-9F, 9F), y, 0);
    }
}
