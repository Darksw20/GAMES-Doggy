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

        // Habilidad de memoria
        if (memoryAbility)
            useMemoryAbility();

        // Agregar movimiento del jugador a una lista
        if (shouldDance && Input.GetKeyDown(KeyCode.UpArrow) ||
                           Input.GetKeyDown(KeyCode.DownArrow) ||
                           Input.GetKeyDown(KeyCode.LeftArrow) ||
                           Input.GetKeyDown(KeyCode.RightArrow))
            addMovementToList(movement.x, movement.y);

        // Verificar si la lista de movimientos del jugador
        // es igual a la lista de cada baile
        if (shouldDance)
        {
            anaAnimator.SetFloat("x", movement.x);
            anaAnimator.SetFloat("y", movement.y);

            checkDanceMoves();
        }
    }
    private void useMemoryAbility()
    {
        memoryAbility = false;
        shouldDance = false;
        if (currentMovement == 1)
        {
            current_1 = dance_1;
            dance(dance_1, "Ana");
            StartCoroutine(nextDance(2));
        }
        else if (currentMovement == 2)
        {
            current_2 = dance_2;
            dance(dance_2, "Ana");
            StartCoroutine(nextDance(3));
        }
        else if (currentMovement == 3)
        {
            current_3 = dance_3;
            dance(dance_3, "Ana");
            StartCoroutine(nextDance(4));
        }
        else if (currentMovement == 4)
        {
            current_4 = dance_4;
            dance(dance_4, "Ana");
        }
    }

    private void addMovementToList(float x, float y)
    {
        string toAdd = null;
        if (x == 1 && y == 0)
            toAdd = "x 1";
        else if (x == -1 && y == 0)
            toAdd = "x -1";
        else if (x == 0 && y == 1)
            toAdd = "y 1";
        else if (x == 0 && y == -1)
            toAdd = "y -1";

        if (currentMovement == 1)
            current_1.Add(toAdd);
        else if (currentMovement == 2)
            current_2.Add(toAdd);
        else if (currentMovement == 3)
            current_3.Add(toAdd);
        else if (currentMovement == 4)
            current_4.Add(toAdd);
    }

    private void checkDanceMoves()
    {
        Debug.Log("Checking dance moves");
        Debug.Log("Current movement: " + currentMovement);
        if (currentMovement == 1 && checkMatch(dance_1, current_1))
            StartCoroutine(nextDance(2));
        else if (currentMovement == 2 && checkMatch(dance_2, current_2))
            StartCoroutine(nextDance(3));
        else if (currentMovement == 3 && checkMatch(dance_3, current_3))
            StartCoroutine(nextDance(4));
        else if (currentMovement == 4 && checkMatch(dance_4, current_4))
        {
            GameManager.instancia.level = 6;
            GameManager.instancia.nextLevel = 7;
            nextLevel();
        }
    }

    private bool checkMatch(List<string> l1, List<string> l2)
    {
        // Revisar si tienen el mismo tamaño
        if (l1.Count != l2.Count)
            return false;

        // Si tienen el mismo tamaño, pero no los mismos datos
        // la animación vuelve a repetirse
        for (int i = 0; i < l1.Count; i++)
        {
            if (l1[i] != l2[i])
            {
                shouldDance = false;
                l2.Clear();
                StartCoroutine(dance(l1, "Perrero"));
                return false;
            }        
        }

        // Las listas son iguales, entonces actualizamos las
        // variables con los bailes y regresamos true
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
        Debug.Log("Next dance");
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
        Debug.Log("Coroutine dance from " + character);
        if (currentMovement == 1)
        {
            steps1.SetActive(true);
        } else if (currentMovement == 2)
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
            Debug.Log(i);
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
        Debug.Log("Finished dance coroutine");
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
