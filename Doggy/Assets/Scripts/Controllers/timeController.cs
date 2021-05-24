using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public int countdownTime;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        countdownTime = GameManager.instancia.time;
        while (countdownTime >= 0)
        {
            GameManager.instancia.time = countdownTime;

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        //que ocurre cuando se termina el codigo?
        
    }
}
