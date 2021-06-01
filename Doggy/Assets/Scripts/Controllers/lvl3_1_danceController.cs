using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_danceController : GameRouting
{
    public GameObject ana;
    public GameObject perrero;

    private Animator anaAnimator;
    private Animator perreroAnimator;

    private Vector2 movement;
    private int currentMovement = 1;
    private bool shouldDance = false;

    private bool memoryAbility = false;

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

    private bool dance1Finished = false;
    private bool dance2Finished = false;
    private bool dance3Finished = false;
    private bool dance4Finished = false;

    private GameObject steps1;
    private GameObject steps2;
    private GameObject steps3;
    private GameObject steps4;

    void Start()
    {
        anaAnimator = ana.GetComponent<Animator>();
        perreroAnimator = perrero.GetComponent<Animator>();
        steps1 = GameObject.Find("steps1");
        steps2 = GameObject.Find("steps2");
        steps3 = GameObject.Find("steps3");
        steps4 = GameObject.Find("steps4");
        steps1.SetActive(false);
        steps2.SetActive(false);
        steps3.SetActive(false);
        steps4.SetActive(false);
        StartCoroutine(dance(dance_1, "Perrero"));
        steps1.SetActive(true);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anaAnimator.SetFloat("x", movement.x);
        anaAnimator.SetFloat("y", movement.y);

        if (memoryAbility)
        {
            shouldDance = false;
            if (currentMovement == 1)
            {
                current_1.Clear();
                current_1.Add("y 1");
                current_1.Add("y -1");
                current_1.Add("y 1");
                StartCoroutine(nextDance(2));
                steps2.SetActive(true);
            } else if (currentMovement == 2)
            {
                current_2.Clear();
                current_2.Add("y -1");
                current_2.Add("x 1");
                current_2.Add("x -1");
                current_2.Add("y 1");
                current_2.Add("x -1");
                current_2.Add("y 1");
                StartCoroutine(nextDance(3));

            } else if (currentMovement == 3)
            {
                current_3.Clear();
                current_3.Add("y 1");
                current_3.Add("y 1");
                current_3.Add("x 1");
                current_3.Add("y -1");
                current_3.Add("x -1");
                current_3.Add("x -1");
                current_3.Add("y -1");
                current_3.Add("x 1");
                StartCoroutine(nextDance(4));

            } else if (currentMovement == 4)
            {
                current_4.Clear();
                current_4.Add("x -1");
                current_4.Add("x 1");
                current_4.Add("x -1");
                current_4.Add("y -1");
                current_4.Add("y 1");
                current_4.Add("y -1");
                current_4.Add("x -1");
                current_4.Add("x -1");
                current_4.Add("x 1");
                dance(dance_4, "Ana");
            }
            memoryAbility = false;
        }

        if (shouldDance)
        {
            if (currentMovement == 1 && checkMatch(dance_1, current_1))
            {
                StartCoroutine(nextDance(2));
            }
            else if (currentMovement == 2 && checkMatch(dance_2, current_2))
            {
                StartCoroutine(nextDance(3));
            }
            else if (currentMovement == 3 && checkMatch(dance_3, current_3))
            {
                StartCoroutine(nextDance(4));
            }
            else if (currentMovement == 4 && checkMatch(dance_4, current_4))
            {
                Level3_2_1();
                // End scene
            }
        }

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
        if (currentMovement == 2)
            dance1Finished = true;
        else if (currentMovement == 3)
            dance2Finished = true;
        else if (currentMovement == 4)
            dance3Finished = true;
        return true;
    }

    IEnumerator nextDance(int next)
    {
        shouldDance = false;
        yield return new WaitForSeconds(1);
        if (next == 1 && !dance1Finished)
        {
            dance1Finished = true;
            current_1.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_1, "Perrero"));
            yield break;
        } else if (next == 2 && !dance2Finished)
        {
            dance2Finished = true;
            current_2.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_2, "Perrero"));
            yield break;
        } else if (next == 3 && !dance3Finished)
        {
            dance3Finished = true;
            current_3.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_3, "Perrero"));
            yield break;
        } else if (next == 4 && !dance4Finished)
        {
            dance4Finished = true;
            current_4.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_4, "Perrero"));
            yield break;
        }
    }

    IEnumerator dance(List<string> list, string character)
    {
        if (currentMovement == 2)
        {
            steps1.SetActive(false);
            steps2.SetActive(true);
        } else if (currentMovement == 3)
        {
            steps2.SetActive(false);
            steps3.SetActive(true);
        } else if (currentMovement == 4)
        {
            steps3.SetActive(false);
            steps4.SetActive(true);
        }
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
            StartCoroutine(danceMovement(name, value, character));
            yield return new WaitForSeconds(1);
        }
        shouldDance = true;
        steps1.SetActive(false);
        steps2.SetActive(false);
        steps3.SetActive(false);
        steps4.SetActive(false);
    }

    IEnumerator danceMovement(string name, float value, string character)
    {
        if (character == "Ana")
        {
            anaAnimator.SetFloat(name, value);
            yield return new WaitForSeconds(1);
            anaAnimator.SetFloat(name, 0);
        } else if (character == "Perrero")
        {
            perreroAnimator.SetFloat(name, value);
            yield return new WaitForSeconds(1);
            perreroAnimator.SetFloat(name, 0);
        }   
    }

    public void setMemory(bool memory)
    {
        memoryAbility = memory;
    }

    public bool getMemory()
    {
        return memoryAbility;
    }

}
