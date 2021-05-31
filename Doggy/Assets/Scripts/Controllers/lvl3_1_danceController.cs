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
    private bool shouldDance = false;

    private List<string> dance_1 = new List<string>
        {
            "y 1",
            "y -1",
            "y 1"
        };
    private List<string> current_1 = new List<string>();
    private List<string> dance_2 = new List<string>
        {
            "y -1",
            "x 1",
            "x -1",
            "y 1",
            "x -1",
            "y 1"
        };
    private List<string> current_2 = new List<string>();
    private List<string> dance_3 = new List<string>
        {
            "y 1",
            "y 1",
            "x 1",
            "y -1",
            "x -1",
            "x -1",
            "y -1",
            "x 1"
        };
    private List<string> current_3 = new List<string>();
    private List<string> dance_4 = new List<string>
        {
            "x -1",
            "x 1",
            "x -1",
            "y -1",
            "y 1",
            "y -1",
            "x -1",
            "x -1",
            "x 1"
        };
    private List<string> current_4 = new List<string>();

    private string toAdd = null;

    void Start()
    {
        current_1.Clear();
        current_2.Clear();
        current_3.Clear();
        current_4.Clear();
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

        if (shouldDance && Input.GetKeyDown(KeyCode.UpArrow) ||
                           Input.GetKeyDown(KeyCode.DownArrow) ||
                           Input.GetKeyDown(KeyCode.LeftArrow) ||
                           Input.GetKeyDown(KeyCode.RightArrow))
        {
            toAdd = null;
            if (movement.x == 1 && movement.y == 0)
            {
                toAdd = "x 1";
            }
            else if (movement.x == -1 && movement.y == 0)
            {
                toAdd = "x -1";
            }
            else if (movement.x == 0 && movement.y == 1)
            {
                toAdd = "y 1";
            }
            else if (movement.x == 0 && movement.y == -1)
            {
                toAdd = "y -1";
            }
            switch (currentMovement)
            {
                case 1:
                    current_1.Add(toAdd);
                    break;

                case 2:
                    current_2.Add(toAdd);
                    break;

                case 3:
                    current_3.Add(toAdd);
                    break;

                case 4:
                    current_4.Add(toAdd);
                    break;
            }
            foreach (var x in current_1)
            {
                Debug.Log(x.ToString());
            }
        }

        if (shouldDance)
        {
            if (checkMatch(dance_1, current_1) ||
                checkMatch(dance_2, current_2) ||
                checkMatch(dance_3, current_3) ||
                checkMatch(dance_4, current_4))
            {
                StartCoroutine(nextDance());
            }
        }
    }

    private bool checkMatch(List<string> l1, List<string> l2)
    {
        if (l1.Count != l2.Count)
            return false;
        for (int i = 0; i < l1.Count; i++)
        {
            if (l1[i] != l2[i])
                return false;
        }
        return true;
    }

    private void firstDance()
    {
        shouldDance = false;
        StartCoroutine(dance(dance_1));
    }

    private void secondDance()
    {
        shouldDance = false;
        StartCoroutine(dance(dance_2));
    }

    private void thirdDance()
    {
        shouldDance = false;
        StartCoroutine(dance(dance_3));
    }

    private void fourthDance()
    {
        shouldDance = false;
        StartCoroutine(dance(dance_4));
    }

    IEnumerator nextDance()
    {
        yield return new WaitForSeconds(1);
        if (currentMovement == 1)
        {
            current_1.Clear();
            secondDance();
        } else if (currentMovement == 2)
        {
            current_2.Clear();
            thirdDance();
        } else if (currentMovement == 3)
        {
            current_3.Clear();
            fourthDance();
        } else if (currentMovement == 5)
        {
            current_4.Clear();
            // Next scene code
        }
        currentMovement++;
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
        shouldDance = true;
    }

    IEnumerator danceMovement(string name, float value)
    {
        perreroAnimator.SetFloat(name, value);
        yield return new WaitForSeconds(1);
        perreroAnimator.SetFloat(name, 0);
    }
}
