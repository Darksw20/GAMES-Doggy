using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineCone : MonoBehaviour
{

    private bool canDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mapa")
        {
            changePosition();
        } else if (collision.gameObject.tag == "Player" && canDamage)
        {
            Debug.Log("health");
            GameManager.instancia.health--;
            GameObject.Find("Maps").GetComponent<level1_2>().resetLevel();
        }
    }

    public void changePosition()
    {
        StartCoroutine(changeCanDamage());
        float y = Random.Range(-3.5F, 4.5F);
        transform.localPosition = new Vector3(Random.Range(-9F, 9F), y, 0);
        GetComponent<Animator>().Play("pineCone", -1, 0);
    }

    IEnumerator changeCanDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(1);
        canDamage = true;
    }
}
