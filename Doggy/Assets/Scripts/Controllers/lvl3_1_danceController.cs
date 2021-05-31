using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_danceController : MonoBehaviour
{

    public GameObject ana;
    public GameObject perrero;

    private Animator anaAnimator;
    private Animator perreroAnimator;

    private Vector2 movement;
    private int currentMovement = 1;

    void Start()
    {
        anaAnimator = ana.GetComponent<Animator>();
        perreroAnimator = perrero.GetComponent<Animator>();
        firstDance();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anaAnimator.SetFloat("x", movement.x);
        anaAnimator.SetFloat("y", movement.y);

    }

    private void firstDance()
    {
        List<string> list = new List<string>();
        list.Add("y 1");
        list.Add("y -1");
        list.Add("y 1");
        StartCoroutine(dance(list));
    }

    private void secondDance()
    {
        List<string> list = new List<string>();
        list.Add("y -1");
        list.Add("x 1");
        list.Add("x -1");
        list.Add("y 1");
        list.Add("x -1");
        list.Add("y 1");
        StartCoroutine(dance(list));
    }

    private void thirdDance()
    {
        List<string> list = new List<string>();
        list.Add("y 1");
        list.Add("y 1");
        list.Add("x 1");
        list.Add("y -1");
        list.Add("x -1");
        list.Add("x -1");
        list.Add("y -1");
        list.Add("x 1");
        StartCoroutine(dance(list));
    }

    private void fourthDance()
    {
        List<string> list = new List<string>();
        list.Add("x -1");
        list.Add("x 1");
        list.Add("x -1");
        list.Add("y -1");
        list.Add("y 1");
        list.Add("y -1");
        list.Add("x -1");
        list.Add("x -1");
        list.Add("x 1");
        StartCoroutine(dance(list));
    }

    IEnumerator dance(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string name = list[i].Substring(0, 1);
            float value;
            if (list[i].Length == 3)
            {
                value = float.Parse(list[i].Substring(1, 2));
            } else
            {
                value = float.Parse(list[i].Substring(1, 3));
            }
            StartCoroutine(danceMovement(name, value));
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator danceMovement(string name, float value)
    {
        perreroAnimator.SetFloat(name, value);
        yield return new WaitForSeconds(1);
        perreroAnimator.SetFloat(name, 0);
    }
}
